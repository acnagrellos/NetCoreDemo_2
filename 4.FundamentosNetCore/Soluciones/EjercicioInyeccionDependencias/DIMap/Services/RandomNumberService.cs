using System;

namespace DIMap.Services
{
    public class RandomNumberService : IRandomNumberService, IRandomNumberServiceScoped, IRandomNumberServiceSingleton
    {
        private int _randomNumber;
        public RandomNumberService()
        {
            var random = new Random();
            _randomNumber = random.Next(100);
        }

        public int GetRandomNumber()
        {
            return _randomNumber;
        }
    }
}
