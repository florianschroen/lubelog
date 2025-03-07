﻿using CarCareTracker.External.Interfaces;
using CarCareTracker.Models;
using LiteDB;

namespace CarCareTracker.External.Implementations
{
    public class ServiceRecordDataAccess: IServiceRecordDataAccess
    {
        private static string dbName = "data/cartracker.db";
        private static string tableName = "servicerecords";
        public List<ServiceRecord> GetServiceRecordsByVehicleId(int vehicleId)
        {
            using (var db = new LiteDatabase(dbName))
            {
                var table = db.GetCollection<ServiceRecord>(tableName);
                var serviceRecords = table.Find(Query.EQ(nameof(ServiceRecord.VehicleId), vehicleId));
                return serviceRecords.ToList() ?? new List<ServiceRecord>();
            };
        }
        public ServiceRecord GetServiceRecordById(int serviceRecordId)
        {
            using (var db = new LiteDatabase(dbName))
            {
                var table = db.GetCollection<ServiceRecord>(tableName);
                return table.FindById(serviceRecordId);
            };
        }
        public bool DeleteServiceRecordById(int serviceRecordId)
        {
            using (var db = new LiteDatabase(dbName))
            {
                var table = db.GetCollection<ServiceRecord>(tableName);
                table.Delete(serviceRecordId);
                return true;
            };
        }
        public bool SaveServiceRecordToVehicle(ServiceRecord serviceRecord)
        {
            using (var db = new LiteDatabase(dbName))
            {
                var table = db.GetCollection<ServiceRecord>(tableName);
                table.Upsert(serviceRecord);
                return true;
            };
        }
        public bool DeleteAllServiceRecordsByVehicleId(int vehicleId)
        {
            using (var db = new LiteDatabase(dbName))
            {
                var table = db.GetCollection<ServiceRecord>(tableName);
                var serviceRecords = table.DeleteMany(Query.EQ(nameof(ServiceRecord.VehicleId), vehicleId));
                return true;
            };
        }
    }
}
