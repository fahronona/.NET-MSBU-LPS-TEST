using System;
namespace MSBU_LPS_TEST.Models
{
	public class BarangModelClass
	{
	   public int IdBarang { get;set; }
       public string? NamaBarang { get; set; }
	   public string? KodeBarang { get; set; }
	   public int JumlahBarang { get; set; }
	   public DateTime Tanggal { get; set; }
    }

    public class CombinedModel
    {
        public  BarangModelClass Barang { get; set; }
        public List<BarangModelClass> ListBarang { get; set; }
    }
}

