using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace TableData.Models
{
  public class Restaurant
  {
    public int RestaurantId { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public int Rating { get; set; }
    public virtual Cuisine Cuisine { get; set; }
  }
}