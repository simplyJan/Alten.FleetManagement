﻿using Core.BaseRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using VehicleTracker.DTO;

namespace VehicleTracker.API.BL
{
    public class PingManager
    {
        private readonly IBaseRepository<Vehicle> _vehiclerepository;

        private static HttpClient client = new HttpClient();
        private string baseaddress = "";
        public PingManager(IBaseRepository<Vehicle> vehiclerepository, string clientbaseurl)
        {
            _vehiclerepository = vehiclerepository;
            baseaddress = clientbaseurl;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<List<VehicleStatus>> GetVehicleStatusesAsync(List<Vehicle> vehicles)
        {
            var vehiclestatuslist = new List<VehicleStatus>();
            foreach (var vehicle in vehicles)
            {
                var response = await client.GetAsync(baseaddress + "api/values/" + vehicle.RegistrationNumber);
                string result = await response.Content.ReadAsStringAsync();
                if (result != null && result != "")
                {
                    VehicleStatus vehicleStatus = new VehicleStatus()
                    {
                        VehicleId = vehicle.Id,
                        Status = Convert.ToBoolean(result)
                    };
                    vehiclestatuslist.Add(vehicleStatus);
                }

            }
            
            return vehiclestatuslist;
        }

    }
}
