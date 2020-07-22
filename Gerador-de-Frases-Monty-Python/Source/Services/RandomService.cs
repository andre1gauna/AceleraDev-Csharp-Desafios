using System;
using System.Text;

namespace Codenation.Challenge.Services
{
    public class RandomService: IRandomService
    {
        public int RandomInteger(int max)
        {
            Random random = new Random();
            return random.Next(max);
        }
    }
}