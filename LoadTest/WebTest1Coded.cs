﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LoadTest {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.WebTesting;
    using Microsoft.VisualStudio.TestTools.WebTesting.Rules;
    
    
    public class WebTest1Coded : WebTest {
        
        public WebTest1Coded() {
            this.PreAuthenticate = true;
            this.Proxy = "default";
        }
        
        public override IEnumerator<WebTestRequest> GetRequestEnumerator() {
            // Initialize validation rules that apply to all requests in the WebTest
            if ((this.Context.ValidationLevel >= Microsoft.VisualStudio.TestTools.WebTesting.ValidationLevel.Low)) {
                ValidateResponseUrl validationRule1 = new ValidateResponseUrl();
                this.ValidateResponse += new EventHandler<ValidationEventArgs>(validationRule1.Validate);
            }
            if ((this.Context.ValidationLevel >= Microsoft.VisualStudio.TestTools.WebTesting.ValidationLevel.Low)) {
                ValidationRuleResponseTimeGoal validationRule2 = new ValidationRuleResponseTimeGoal();
                validationRule2.Tolerance = 0D;
                this.ValidateResponseOnPageComplete += new EventHandler<ValidationEventArgs>(validationRule2.Validate);
            }

            WebTestRequest request1 = new WebTestRequest("https://bpcalctest-bccalcjlp.azurewebsites.net/");
            request1.Version = "1.0";
            yield return request1;
            request1 = null;

            WebTestRequest request2 = new WebTestRequest("https://bpcalctest-bccalcjlp.azurewebsites.net/BloodPressure");
            request2.ThinkTime = 6;
            request2.Headers.Add(new WebTestRequestHeader("Referer", "https://bpcalctest-bccalcjlp.azurewebsites.net/"));
            ExtractHiddenFields extractionRule1 = new ExtractHiddenFields();
            extractionRule1.Required = true;
            extractionRule1.HtmlDecode = true;
            extractionRule1.ContextParameterName = "1";
            request2.ExtractValues += new EventHandler<ExtractionEventArgs>(extractionRule1.Extract);
            yield return request2;
            request2 = null;

            WebTestRequest request3 = new WebTestRequest("https://bpcalctest-bccalcjlp.azurewebsites.net/BloodPressure");
            request3.ThinkTime = 3;
            request3.Method = "POST";
            request3.Headers.Add(new WebTestRequestHeader("Referer", "https://bpcalctest-bccalcjlp.azurewebsites.net/BloodPressure"));
            FormPostHttpBody request3Body = new FormPostHttpBody();
            request3Body.FormPostParameters.Add("BP.Systolic", "120");
            request3Body.FormPostParameters.Add("BP.Diastolic", "60");
            request3Body.FormPostParameters.Add("__RequestVerificationToken", this.Context["$HIDDEN1.__RequestVerificationToken"].ToString());
            request3.Body = request3Body;
            ExtractHiddenFields extractionRule2 = new ExtractHiddenFields();
            extractionRule2.Required = true;
            extractionRule2.HtmlDecode = true;
            extractionRule2.ContextParameterName = "1";
            request3.ExtractValues += new EventHandler<ExtractionEventArgs>(extractionRule2.Extract);
            yield return request3;
            request3 = null;

            WebTestRequest request4 = new WebTestRequest("https://bpcalctest-bccalcjlp.azurewebsites.net/BloodPressure");
            request4.Method = "POST";
            request4.Headers.Add(new WebTestRequestHeader("Referer", "https://bpcalctest-bccalcjlp.azurewebsites.net/BloodPressure"));
            FormPostHttpBody request4Body = new FormPostHttpBody();
            request4Body.FormPostParameters.Add("BP.Systolic", "120");
            request4Body.FormPostParameters.Add("BP.Diastolic", "80");
            request4Body.FormPostParameters.Add("__RequestVerificationToken", this.Context["$HIDDEN1.__RequestVerificationToken"].ToString());
            request4.Body = request4Body;
            yield return request4;
            request4 = null;
        }
    }
}
