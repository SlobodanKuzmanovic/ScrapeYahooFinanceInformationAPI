using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer
{
    public class AssetProfileModel
    {
        public Meta meta { get; set; }
        public Body body { get; set; }

        public AssetProfileModel()
        {
            meta = new Meta();
            body = new Body();
        }
    }

    public class Meta
    {
        public string version { get; set; }
        public int status { get; set; }
        public string copywrite { get; set; }
        public string symbol { get; set; }
        public DateTime processedTime { get; set; }
        public string modules { get; set; }
    }

    public class Body
    {
        public string address1 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public string industry { get; set; }
        public string industryKey { get; set; }
        public string industryDisp { get; set; }
        public string sector { get; set; }
        public string sectorKey { get; set; }
        public string sectorDisp { get; set; }
        public string longBusinessSummary { get; set; }
        public int fullTimeEmployees { get; set; }
        public List<CompanyOfficer> companyOfficers { get; set; }
        public int auditRisk { get; set; }
        public int boardRisk { get; set; }
        public int compensationRisk { get; set; }
        public int shareHolderRightsRisk { get; set; }
        public int overallRisk { get; set; }
        public int governanceEpochDate { get; set; }
        public int compensationAsOfEpochDate { get; set; }
        public int maxAge { get; set; }

        public Body()
        {
            companyOfficers = new List<CompanyOfficer>();
        }
    }

    public class CompanyOfficer
    {
        public int maxAge { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string title { get; set; }
        public int yearBorn { get; set; }
        public int fiscalYear { get; set; }
        public TotalPay totalPay { get; set; }
        public ExercisedValue exercisedValue { get; set; }
        public UnexercisedValue unexercisedValue { get; set; }

        public CompanyOfficer()
        {
            totalPay = new TotalPay();
            exercisedValue = new ExercisedValue();
            unexercisedValue = new UnexercisedValue();
        }
    }

    public class ExercisedValue
    {
        public long raw { get; set; }
        public object fmt { get; set; }
        public string longFmt { get; set; }
    }

    public class TotalPay
    {
        public long raw { get; set; }
        public string fmt { get; set; }
        public string longFmt { get; set; }
    }

    public class UnexercisedValue
    {
        public long raw { get; set; }
        public object fmt { get; set; }
        public string longFmt { get; set; }
    }
}
