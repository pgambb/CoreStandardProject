﻿using Dapper;
using System;
using System.Data;
using SSMDapperV2;

namespace CoreStandardProject.DATA.Model.Global
{
    public class ErrorLogging : Repository
    {
        public Guid Id { get; set; }
        public string StackTrace { get; set; }
        public string Message { get; set; }
        public string JSON { get; set; }
        public DateTime ErrorDate { get; set; }

        public ErrorLogging() : base("NewTemplateDatabase")
        {

        }

        public Guid Save()
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("StackTrace", StackTrace, DbType.String);
            parameters.Add("Message", Message, DbType.String);
            parameters.Add("JSON", JSON, DbType.String);

            return GetSingle<Guid>("CaptureError", parameters);
        }
    }
}
