using System;
using NUnit.Framework;

namespace CSharp8.Features
{
    public interface IOrderTotalCalculator
    {
        DateTime RegisteredSince { get; }
        decimal SubTotal { get; }
        decimal CalculateTotal();

        public decimal CalculateDiscount()
        {
            return 0;
        }
    }

    public class RewardProgramOrderTotal : IOrderTotalCalculator
    {
        public decimal SubTotal { get; private set; }
        public DateTime RegisteredSince { get; private set; }
        private readonly int _orderCount;
        private readonly decimal _bookingFee = .99m;

        public RewardProgramOrderTotal(decimal subTotal, DateTime registeredSince, int orderCount)
        {
            SubTotal = subTotal;
            RegisteredSince = registeredSince;
            _orderCount = orderCount;
        }

        public decimal CalculateTotal()
        {
            return SubTotal - _bookingFee;
        }

        public decimal CalculateDiscount()
        {
            if (_orderCount > 10)
            {
                return 0.1m;
            }

            return 0m;
        }
    }

    class LoyaltyOrderTotal : IOrderTotalCalculator
    {
        public decimal SubTotal { get; private set; }
        public DateTime RegisteredSince { get; private set; }

        public LoyaltyOrderTotal(decimal subTotal, DateTime registeredSince)
        {
            SubTotal = subTotal;
            RegisteredSince = registeredSince;
        }

        public decimal CalculateTotal()
        {
            return SubTotal;
        }
    }

    [TestFixture]
    public class TestDefaultInterfaceMethods
    {
        [Test]
        public void CanAccessDefaultMethod()
        {
            LoyaltyOrderTotal loyaltyDiscount = new LoyaltyOrderTotal(20m, new DateTime(2010, 1, 1));
            var discountPercentage = ((IOrderTotalCalculator) loyaltyDiscount).CalculateDiscount();
            Assert.AreEqual(0, discountPercentage);
        }
        [Test]
        public void CanOverrideDefaukltInterfaceMethod()
        {
            var rewardsDiscount = new RewardProgramOrderTotal(20m, new DateTime(2010, 1, 1), 25);
            var discountPercentage = rewardsDiscount.CalculateDiscount();
            Assert.AreEqual(0.10, discountPercentage);
        }  
    }
}