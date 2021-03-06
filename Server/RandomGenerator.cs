﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace Server
{
    class RandomGenerator
    {
        private IHubContext _hubs;
        private readonly int _pollIntervalMillis;
        static Random _numberRand;

        public RandomGenerator(int pollIntervalMillis)
        {
            //HostingEnvironment.RegisterObject(this);
            _hubs = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            _pollIntervalMillis = pollIntervalMillis;
            _numberRand = new Random();
        }

        public async Task OnRandomMonitor()
        {
            while (true)
            {
                await Task.Delay(_pollIntervalMillis);
                int number = _numberRand.Next(0, 50);

                _hubs.Clients.All.broadcastData(number, DateTime.Now);
            }
        }
    }
}
