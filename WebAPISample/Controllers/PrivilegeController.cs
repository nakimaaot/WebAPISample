using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPISample.Models;

namespace WebAPISample.Controllers
{
    public class PrivilegeController : ApiController
    {

        [HttpGet]
        public ResponseDataModel<object> GetSampleData()
        {
            // Call Soap API - Generate จากการ Add Service Reference
            SampleReference.FedACHSoapClient client = new SampleReference.FedACHSoapClient();
            SampleReference.FedACHList fedACHLists;

            // Call method getACHByZipCode
            // param: 72201
            // response: FedACHList
            client.getACHByZipCode("72201", out fedACHLists);

            // Mapping Response
            var responseData = new ResponseDataModel<object>();
            responseData.Code = "000";
            responseData.Status = "success";
            responseData.Message = "method GetSampleData";
            responseData.Data = fedACHLists;

            return responseData;

            // ถ้าเขียนแบบ AIS ให้แก้ตามด้านล่าง
            // var responseMessage = new HttpResponseMessage();
            // return responseMessage.CreateStringContent(responseData, HttpStatusCode.OK);
        }

    }
}
