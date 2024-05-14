using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SelfCheckoutMachine.Core.DTO;
using SelfCheckoutMachine.Domain.Interfaces;
using SelfCheckoutMachine.Domain.Models;

namespace SelfCheckoutMachine.WebApi.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class CheckoutMachineController(ILogger<CheckoutMachineController> logger, IMapper mapper, IStockRepository stockRepository, ICheckoutBusinessLogic businessLogic) : ControllerBase
    {
        private readonly ILogger<CheckoutMachineController> _logger = logger;
        private readonly IMapper _mapper = mapper;
        private readonly IStockRepository _stockRepository = stockRepository;
        private readonly ICheckoutBusinessLogic _businessLogic = businessLogic;
        private List<Stock> stocks = null!;
        [HttpPost]
        [Route("stock")]
        public async Task<IActionResult> CreateStocks([FromBody] CreateStockRequestDTO createStockRequestDTO)
        {
            _logger.LogInformation("Check if model is invalid.");
            if (!ModelState.IsValid)
            {
                return BadRequest("The model is invalid. Please check the input information");
            }
            _logger.LogInformation("Initializing stocks list");
            this.stocks = [];
            foreach (KeyValuePair<string, int> item in createStockRequestDTO.Inserted)
            {
                _logger.LogInformation($"Add item: \"{item.Key}\": {item.Value}");
                this.stocks.Add(new Stock { MoneyValue = Int32.Parse(item.Key), Count = item.Value });
            }

            _logger.LogInformation("Creating stocks list");
            await _stockRepository.CreateStocksAsync(this.stocks);
            return RedirectToAction("GetAllStocks");

        }
        [HttpGet]
        [Route("stocks")]
        public async Task<IActionResult> GetAllStocks()
        {
            this.stocks = await _stockRepository.ReadAllStocksAsync();
            return Ok(this.stocks);
        }
        [HttpPost]
        [Route("checkout")]
        public async Task<IActionResult> CreateCheckout([FromBody] CreateCheckoutRequestDTO createCheckoutRequestDTO)
        {
            _logger.LogInformation("Check if model is invalid.");
            if (!ModelState.IsValid)
            {
                return BadRequest("The model is invalid. Please check the input information!");
            }
            Checkout checkout = new Checkout();
            checkout.Price = createCheckoutRequestDTO.Price;
            foreach (KeyValuePair<string,int> item in createCheckoutRequestDTO.Inserted)
            {
                checkout.Payed += Int32.Parse(item.Key) * item.Value; 

            }
            CreateCheckoutResponseDTO createCheckoutResponseDTO = await _businessLogic.CheckoutAsync(checkout);
            return Ok(createCheckoutResponseDTO.Return);
        }
    }
}
