using PocGetNet.Configurations;
using PocGetNet.DTOs;
using PocGetNet.Repositories;
using System;
using System.Threading.Tasks;

namespace PocGetNet
{
    class Program
    {
        static async Task Main(string[] args)
        {
            /*
             * 
             */
            var configurations = new AppConfigurations();
            var getNetRepository = new GetNetRepository(configurations);
            /**/

            /*
             * AUTHENTICATION
             */
            var auth = await getNetRepository.Authentication();

            /*
             * CARD TOKENIZATION
             */
            var cardTokenizationRequest = new CardTokenizationRequestDto { CardNumber = "5155901222280001", CustomerId = Guid.NewGuid().ToString() };
            var cardTokenized = await getNetRepository.CardTokenization(auth, cardTokenizationRequest);

            /*
             * PAYMENT
             */
            var paymentRequestDto = CreatePaymentRequestDto();
            var payment = await getNetRepository.Payment(auth, paymentRequestDto);
            Console.WriteLine(payment.ToString());
        }

        private static PaymentRequestDto CreatePaymentRequestDto()
        {
            return new PaymentRequestDto();
        }
    }
}
