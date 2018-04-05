using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Atensoli
{
    public partial class EmpresaSucursal : Seguridad.SeguridadAuditoria
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            CargarEmpresa();
        }
        private void CargarEmpresa()
        {
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "select * From Empresa ORDER BY NombreEmpresa";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlEmpresa.DataSource = cmd.ExecuteReader();
                    ddlEmpresa.DataTextField = "NombreEmpresa";
                    ddlEmpresa.DataValueField = "EmpresaID";
                    ddlEmpresa.DataBind();
                    con.Close();
                }
            }
        }
        private void ProcesoSucursal()
        {
            CEmpresaSucursal objetoEmpresaSucursal = new CEmpresaSucursal();
            objetoEmpresaSucursal.EmpresaSucursalID = Convert.ToInt32(hdnEmpresaSucursalID.Value);
            objetoEmpresaSucursal.EmpresaID = Convert.ToInt32(ddlEmpresa.SelectedValue);
            objetoEmpresaSucursal.NombreSucursal = txtNombreSucursal.Text.ToUpper();
            objetoEmpresaSucursal.DireccionSucursal = txtDireccionSucursal.Text.ToUpper();
            objetoEmpresaSucursal.TelefonoSucursal = txtTelefonoSucursal.Text;

            EmpresaSucursal.InsertarEmpresaSucursal(objetoEmpresaSucursal);
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            ProcesoSucursal();
        }
    }
}