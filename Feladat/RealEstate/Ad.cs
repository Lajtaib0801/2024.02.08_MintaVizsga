using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RealEstate
{

    public class Ad
    {
        public int id { get; set; }
        public int rooms { get; set; }
        public string latLong { get; set; }
        public int floors { get; set; }
        public int area { get; set; }
        public string description { get; set; }
        public bool freeOfCharge { get; set; }
        public string imageUrl { get; set; }
        public Seller seller { get; set; }
        public Category category { get; set; }
        public DateTime createAt { get; set; }

        public Ad(int id, int rooms, string latLong, int floors, int area, string description, bool freeOfCharge, string imageUrl, Seller seller, Category category, DateTime createAt)
        {
            this.id = id;
            this.rooms = rooms;
            this.latLong = latLong;
            this.floors = floors;
            this.area = area;
            this.description = description;
            this.freeOfCharge = freeOfCharge;
            this.imageUrl = imageUrl;
            this.seller = seller;
            this.category = category;
            this.createAt = createAt;
        }

        public static List<Ad> LoadFromJson(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            string json = sr.ReadToEnd();
            List<Ad>? adList = JsonSerializer.Deserialize<List<Ad>>(json);
            sr.Close();
            return adList;
        }

        public static double GetAverage(List<Ad> adList) => adList.Where(x => x.floors == 0).Average(x => x.area);

        public static double DistanceTo(Ad estate, double gps1, double gps2)
        {
            string[] slices = estate.latLong.Split(',');
            slices[0] = slices[0].Replace('.',',');
            slices[1] = slices[1].Replace('.',',');
            double c = Math.Pow(double.Parse(slices[0]) - gps1, 1) + Math.Pow(double.Parse(slices[1]) - gps2, 2);
            return Math.Sqrt(c);
        }

        //public static Ad? GetClosest(List<Ad> adList, double gps1, double gps2) =>
        //       adList.Where(x => x.freeOfCharge).Where(x => adList.Min(y => DistanceTo(y, gps1, gps2)) == DistanceTo(x, gps1, gps2)).FirstOrDefault();
        public static Ad? GetClosest(List<Ad> adList, double gps1, double gps2) =>
               adList.Where(x => x.freeOfCharge).OrderBy(x => DistanceTo(x, gps1, gps2)).FirstOrDefault();
    }

}
