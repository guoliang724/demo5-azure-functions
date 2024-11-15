using System;
using Azure.Storage.Queues.Models;
using FunctionApp1.Data;
using FunctionApp1.Model;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionApp1
{
    public class OnQueueTriggerUpdateDatabase
    {
        private readonly ILogger<OnQueueTriggerUpdateDatabase> _logger;
        private readonly AzurefunctionDbContext _context;
        public OnQueueTriggerUpdateDatabase(ILogger<OnQueueTriggerUpdateDatabase> logger,AzurefunctionDbContext azurefunctionDbContext)
        {
            _logger = logger;
            _context = azurefunctionDbContext;  
        }

        [Function(nameof(OnQueueTriggerUpdateDatabase))]
        public void Run([QueueTrigger("SalesRequestInBound", Connection = "AzureWebJobsStorage")] SalesRequest myQueueItem)
        {
            _logger.LogInformation($"C# Queue trigger function processed: {myQueueItem}");

            myQueueItem.Status = "Submit";
            _context.SalesRequests.Add(myQueueItem);
            _context.SaveChanges();

        }
    }
}
