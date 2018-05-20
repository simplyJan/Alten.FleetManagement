﻿

using FleetManager.DTO;

namespace FleetManager.Repository
{
    public static class SQLHelper
    {
        public static string connection = @"Server=.;Database=AltenVehicleDB;Trusted_Connection=True;ConnectRetryCount=4";

        /// <summary>
        /// Adding some test data to in db
        /// </summary>
        /// <param name="context"></param>
        public static void AddTestData(FleetManagerContext context)
        {
            #region Adding Clients

            var testClient1 = new Client
            {
                Name = "Kalles Grustransporter AB",
                Adress = "Cementvägen 8, 111 11 Södertälje"
            };

            context.Clients.Add(testClient1);

            var testClient2 = new Client
            {
                Name = "Johans Bulk AB",
                Adress = "Balkvägen 12, 222 22 Stockholm"
            };

            context.Clients.Add(testClient2);

            var testClient3 = new Client
            {
                Name = "Haralds Värdetransporter AB",
                Adress = "Budgetvägen 1, 333 33 Uppsala"

            };

            context.Clients.Add(testClient3);

            #endregion

            #region Adding Vehicles

            // for first owner
            var testV1 = new Vehicle
            {
                VIN = "YS2R4X20005399401",
                RegistrationNumber = "ABC123",
                OwnerId = testClient1.Id
            };

            context.Vehicles.Add(testV1);

            var testV2 = new Vehicle
            {
                VIN = "VLUR4X20009093588",
                RegistrationNumber = "DEF456",
                OwnerId = testClient1.Id
            };

            context.Vehicles.Add(testV2);

            var testV3 = new Vehicle
            {
                VIN = "VLUR4X20009048066",
                RegistrationNumber = "GHI789",
                OwnerId = testClient1.Id
            };

            context.Vehicles.Add(testV3);


            // for second owner
            var testV4 = new Vehicle
            {
                VIN = "YS2R4X20005388011",
                RegistrationNumber = "JKL012",
                OwnerId = testClient2.Id
            };

            context.Vehicles.Add(testV4);

            var testV5 = new Vehicle
            {
                VIN = "YS2R4X20005387949",
                RegistrationNumber = "MNO345",
                OwnerId = testClient2.Id
            };

            context.Vehicles.Add(testV5);

            // for third owner

            var testV6 = new Vehicle
            {
                // there is a similar vin in the test so i changed it
                VIN = "VLUR4X20009048067",
                RegistrationNumber = "PQR678",
                OwnerId = testClient3.Id
            };

            context.Vehicles.Add(testV6);

            var testV7 = new Vehicle
            {
                VIN = "YS2R4X20005387055",
                RegistrationNumber = "STU901",
                OwnerId = testClient3.Id
            };

            context.Vehicles.Add(testV7);

            #endregion


            context.SaveChanges();
        }
    }
}
