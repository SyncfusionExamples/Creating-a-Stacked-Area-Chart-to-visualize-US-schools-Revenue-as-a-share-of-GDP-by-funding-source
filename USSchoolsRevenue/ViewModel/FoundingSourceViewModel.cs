using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace USSchoolsRevenue
{
    public class FoundingSourceViewModel
    {
        private ObservableCollection<FundingSourceModel> fundingSourceCollection = new ObservableCollection<FundingSourceModel>();

        public ObservableCollection<FundingSourceModel> FundingSourceCollection
        {
            get
            {
                return fundingSourceCollection;
            }
            set
            {
                fundingSourceCollection = value;
            }
        }

        public FoundingSourceViewModel()
        {
            FundingSourceCollection = new ObservableCollection<FundingSourceModel>();
            ReadCSV();
        }

        public void ReadCSV()
        {
            Assembly executingAssembly = typeof(App).GetTypeInfo().Assembly;
            Stream? inputStream = executingAssembly.GetManifestResourceStream("USSchoolsRevenue.Resources.raw.data.csv");
            string? line;
            List<string> lines = new List<string>();
            if (inputStream != null)
            {
                using StreamReader reader = new StreamReader(inputStream);
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
                lines.RemoveAt(0);
                foreach (var dataPoint in lines)
                {
                    string[] data = dataPoint.Split(',');

                    string year = data[0];
                    var localFund = Convert.ToDouble(data[1]);
                    var stateFund = Convert.ToDouble(data[2]);
                    var federalFund = Convert.ToDouble(data[3]);
                    FundingSourceCollection.Add(new FundingSourceModel(year, localFund, stateFund, federalFund));
                }
            }
        }
    }
}
