using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Formaggi.Model
{
    public class Cheese
    {
        //public static int _ID { get;  set; }
        public int ID { get; set; }
        public string CheeseName {  get; set; }
        public string AgingPeriod { get; set; }
        public string Texture { get; set; }
        public string Description {  get; set; }
        public int maker_id {  get; set; }
        public Cheese()
        {
            ID = 0; 
            CheeseName = String.Empty;
            AgingPeriod = String.Empty;
            Texture = String.Empty;
            Description = String.Empty;
            maker_id = 1;

        }
        public override string ToString()
        {
            return $"Cheese ID: {ID}, Name: {CheeseName}, Aging Period: {AgingPeriod}, Texture: {Texture}, Description: {Description}, Maker ID: {maker_id}";
        }
    }
}
