using System.Data;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MSBU_LPS_TEST.Models;
using MySql.Data.MySqlClient;

namespace MSBU_LPS_TEST.Controllers;

public class HomeController : Controller
{


    private readonly ILogger<HomeController> _logger;
    private readonly IConfiguration _configuration;

    public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;

    }



    public IActionResult Index()
    {
        List<BarangModelClass> barang = new List<BarangModelClass>();
        DataTable dt = new DataTable();
        using (MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            try
            {

                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand("GetProduk", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);

                    for (var i = 0; i < dt.Rows.Count; i++)
                    {

                        BarangModelClass barangModel = new BarangModelClass();
                        barangModel.IdBarang = Convert.ToInt32(dt.Rows[i]["id"]);
                        barangModel.NamaBarang = (string?)dt.Rows[i]["nama_barang"];
                        barangModel.KodeBarang = (string?)dt.Rows[i]["kode_barang"];
                        barangModel.JumlahBarang = (int)dt.Rows[i]["jumlah_barang"];
                        barangModel.Tanggal = Convert.ToDateTime(dt.Rows[i]["tanggal"]);
                        barang.Add(barangModel);
                    }
                }

                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                connection.Close();
            }
        }

        BarangModelClass barangM = new BarangModelClass();
        CombinedModel com = new CombinedModel { Barang = barangM, ListBarang = barang };

        return View(com);

    }


    [HttpPost]
    public IActionResult Delete(int id)
    {
        try
        {

            using (MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand("DeleteProduk", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_id", id);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {

            return RedirectToAction("Error", new { message = ex.Message });
        }
    }



    [HttpPost]
    public IActionResult Upload(CombinedModel model)
    {


        try
        {

            using (MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand("AddProduk", connection))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_nama_barang", model.Barang.NamaBarang);
                    cmd.Parameters.AddWithValue("@p_kode_barang", model.Barang.KodeBarang);
                    cmd.Parameters.AddWithValue("@p_jumlah_barang", model.Barang.JumlahBarang);
                    cmd.Parameters.AddWithValue("@p_tanggal", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }

                connection.Close();
            }

            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            return RedirectToAction("Error", new { message = e.Message });
        }


    }


    [HttpPost]
    public IActionResult Update(BarangModelClass barang)
    {
        try
        {

            using (MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand("UpdateProduk", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_id", barang.IdBarang);
                    cmd.Parameters.AddWithValue("@p_nama_barang", barang.NamaBarang);
                    cmd.Parameters.AddWithValue("@p_kode_barang", barang.KodeBarang);
                    cmd.Parameters.AddWithValue("@p_jumlah_barang", barang.JumlahBarang);
                    cmd.Parameters.AddWithValue("@p_tanggal", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }

                connection.Close();
            }

            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            return RedirectToAction("Error", new { message = e.Message });
        }
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

