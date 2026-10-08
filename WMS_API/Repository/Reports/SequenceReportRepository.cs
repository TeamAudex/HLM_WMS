using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POMS.Entity;
using System.Data.SqlClient;
using System.Data;
using POMS.Entity.Masters;
using POM.Repository;
using Librarys.Extenders;
using Librarys;
using POMS.Entity.Operations;
using POMS.Repository.Operations;
using System.IO;


namespace POMS.Repository
{
    public class SequenceReportRepository : RepositoryBaseNew
    {

        const string _SequenFetch = "SequenceDiagramDetails";
        const string _ManualSequenFetch= "ManualSequenceDiagramDetails";
        const string _ManualSeqExcelFetch = "ManualSequenceExcelReport";
        const string _SeqExcelFetch = "SequenceExcelReport";

        public string SequenceImageDownload(SeqDetails obj1)
        {
            string TlopImagePath = "";
            List<CompareLspFTLRow1> CompareLspFTLRows = new List<CompareLspFTLRow1>();

            List<SqlParameter> objListOfsqlParameters = new List<SqlParameter>();

            SqlParameter SequenceRepo = new SqlParameter();
            SequenceRepo.ParameterName = "@SequenceDiagramDetails";
            SequenceRepo.SqlDbType = SqlDbType.Structured;
            SequenceRepo.Value = obj1.objSeqDiagram.ToDataTable<CompareLspFTLRow1>();
            SequenceRepo.Direction = ParameterDirection.Input;
            objListOfsqlParameters.Add(SequenceRepo);


            if (obj1.typeofWaypoint == "G")
            {
                SqlParameter SequenceRepo1 = new SqlParameter();
            SequenceRepo1.ParameterName = "@WaypointDetails";
            SequenceRepo1.SqlDbType = SqlDbType.Structured;
            SequenceRepo1.Value = obj1.objwaypoint.ToDataTable<waypointSrting2>();
            SequenceRepo1.Direction = ParameterDirection.Input;
            objListOfsqlParameters.Add(SequenceRepo1);
            }

            else
            {
                SqlParameter SequenceRepo1 = new SqlParameter();
                SequenceRepo1.ParameterName = "@WaypointDetails";
                SequenceRepo1.SqlDbType = SqlDbType.Structured;
                SequenceRepo1.Value = obj1.objwaypoint2.ToDataTable<waypointSrting2>();
                SequenceRepo1.Direction = ParameterDirection.Input;
                objListOfsqlParameters.Add(SequenceRepo1);

            }



            SqlParameter paramindex = new SqlParameter("@VehicleInstanceId1", obj1.VehicleInstanceId1);
            paramindex.SqlDbType = SqlDbType.Int;
            objListOfsqlParameters.Add(paramindex);


            SqlParameter paraminde1 = new SqlParameter("@VehicleSno1", obj1.VehicleSno1);
            paraminde1.SqlDbType = SqlDbType.Int;
            objListOfsqlParameters.Add(paraminde1);



            DataSet dataSet = ExecuteCommand(_SequenFetch, objListOfsqlParameters);
            //string result = ds.Tables[0].Rows[0][0].ToString();



            TruckLoadOptmizePlaner objplaner;
            TruckLoadOptmizePlanerEntity obj = new TruckLoadOptmizePlanerEntity();

            try
            {
                obj.Items = dataSet.Tables[0].ToCollection<TLOPItem>();
                obj.ExtraItems = dataSet.Tables[1].ToCollection<TLOPItem>();
                obj.Vehicles = dataSet.Tables[2].ToCollection<TLOPVehicle>();
                if (obj.Vehicles.Count > 0)
                {
                    obj.Vehicles[0].VehicleSection = dataSet.Tables[3].ToCollection<TLOPVehicleSection>();
                }
                //  objDocGen.CustomerType = dataSet.Tables[4].Rows[0][0].ToString();
                obj.IsSingleVehicle = true;

                objplaner = new TruckLoadOptmizePlaner(obj);
              //  obj = objplaner.BuildIt();
              
                    byte[] SequencePDf = objplaner.SysGetPDF(obj.Vehicles);

                // byte[] SequencePDf = objplaner.GetPDF();//Diagram Call

                if (obj.TLOPInstances.Count > 0)
                {
                    CompareLspFTLRows = new List<CompareLspFTLRow1>();

                    //    foreach (TLOPRow trc in obj.TLOPInstances[0].Rows)
                    foreach (TLOPItem trc in obj.Items)
                    {
                        CompareLspFTLRow1 clf = new CompareLspFTLRow1();
                        clf.InstanceGroupId = 1;
                        clf.InstanceId = 1;
                        clf.VehicleTypeSno = obj.Vehicles[0].VehicleSno;
                        clf.RowId = trc.RowId;
                        clf.SubId = trc.SubId;
                        clf.ItemId = trc.ItemId;
                        clf.ItemSno = trc.ItemSno;
                        clf.OrderSno = trc.OrderSno;
                        clf.Height = trc.Height;
                        clf.Width = trc.Width;
                        clf.Length = trc.Length;
                        clf.Qty = trc.Qty;
                        clf.BalQty = trc.BalQty;
                        clf.TakenWeight = trc.TakenWeight;
                        clf.TakenVolume = trc.TakenVolume;
                        clf.BalWeight = trc.BalWeight;
                        clf.BalVolume = trc.BalVolume;
                        clf.BalHeight = trc.BalHeight;//
                        clf.BalWidth = trc.BalWidth;//
                        clf.BalLength = trc.BalLength;//
                        clf.Level = trc.Level;
                        clf.Column = trc.Column;
                        clf.WayofPutting = trc.WayofPutting;
                        clf.Priority = trc.Priority;
                        // clf.SectionOrder = trc.SectionOrder;//
                        clf.OrginX = trc.OrginX;
                        clf.OrginY = trc.OrginY;
                        CompareLspFTLRows.Add(clf);
                    }
                }


                TlopImagePath = System.Configuration.ConfigurationManager.ConnectionStrings["FileUpload"].ConnectionString + "\\TlopDrawing\\" + Guid.NewGuid().ToString() + ".pdf";
                File.WriteAllBytes(TlopImagePath, SequencePDf);

            }
            catch (Exception eae) { }




            return TlopImagePath;

        }



        public string ManualSeqImgDownload(ManualSeqDetails obj1)
        {


            string TlopImagePath = "";
            List<CompareLspFTLRow1> CompareLspFTLRows = new List<CompareLspFTLRow1>();

            List<SqlParameter> objListOfsqlParameters = new List<SqlParameter>();

            SqlParameter paramLength = new SqlParameter("@Length", obj1.Length);
            paramLength.SqlDbType = SqlDbType.VarChar;
            objListOfsqlParameters.Add(paramLength);

            SqlParameter paramBreadth = new SqlParameter("@Breadth", obj1.Breadth);
            paramBreadth.SqlDbType = SqlDbType.VarChar;
            objListOfsqlParameters.Add(paramBreadth);

            SqlParameter paramHeight = new SqlParameter("@Height", obj1.Height);
            paramHeight.SqlDbType = SqlDbType.VarChar;
            objListOfsqlParameters.Add(paramHeight);

            SqlParameter paramVolume = new SqlParameter("@Volume", obj1.Volume);
            paramVolume.SqlDbType = SqlDbType.VarChar;
            objListOfsqlParameters.Add(paramVolume);


            SqlParameter paramCarringCapacityt = new SqlParameter("@CarringCapacity", obj1.CarringCapacity);
            paramCarringCapacityt.SqlDbType = SqlDbType.VarChar;
            objListOfsqlParameters.Add(paramCarringCapacityt);



            SqlParameter SequenceRepo = new SqlParameter();
            SequenceRepo.ParameterName = "@SequenceDiagramDetails";
            SequenceRepo.SqlDbType = SqlDbType.Structured;
            SequenceRepo.Value = obj1.objSeqDiagram.ToDataTable<CompareLspFTLRow1>();
            SequenceRepo.Direction = ParameterDirection.Input;
            objListOfsqlParameters.Add(SequenceRepo);

            SqlParameter SequenceRepo1 = new SqlParameter();
            SequenceRepo1.ParameterName = "@WaypointDetails";
            SequenceRepo1.SqlDbType = SqlDbType.Structured;
            SequenceRepo1.Value = obj1.objwaypoint.ToDataTable<waypointSrting2>();
            SequenceRepo1.Direction = ParameterDirection.Input;
            objListOfsqlParameters.Add(SequenceRepo1);


            SqlParameter paramindex = new SqlParameter("@VehicleInstanceId1", obj1.VehicleInstanceId1);
            paramindex.SqlDbType = SqlDbType.Int;
            objListOfsqlParameters.Add(paramindex);




            DataSet dataSet = ExecuteCommand(_ManualSequenFetch, objListOfsqlParameters);
            //string result = ds.Tables[0].Rows[0][0].ToString();



            TruckLoadOptmizePlaner objplaner;
            TruckLoadOptmizePlanerEntity obj = new TruckLoadOptmizePlanerEntity();

            try
            {
                obj.Items = dataSet.Tables[0].ToCollection<TLOPItem>();
                obj.ExtraItems = dataSet.Tables[1].ToCollection<TLOPItem>();
                obj.Vehicles = dataSet.Tables[2].ToCollection<TLOPVehicle>();
                if (obj.Vehicles.Count > 0)
                {
                    obj.Vehicles[0].VehicleSection = dataSet.Tables[3].ToCollection<TLOPVehicleSection>();
                }
                //  objDocGen.CustomerType = dataSet.Tables[4].Rows[0][0].ToString();
                obj.IsSingleVehicle = true;

                objplaner = new TruckLoadOptmizePlaner(obj);

                // obj = objplaner.BuildIt1();
                //byte[] SequencePDf = objplaner.ManualGetPDF();//Diagram Call 

                objplaner.TLOP.Items = obj.Items;
                byte[] SequencePDf = objplaner.ManualGetPDF(obj.Vehicles);//Diagram Call              




                if (obj.TLOPInstances.Count > 0)
                {
                    CompareLspFTLRows = new List<CompareLspFTLRow1>();

                    //    foreach (TLOPRow trc in obj.TLOPInstances[0].Rows)
                    foreach (TLOPItem trc in obj.Items)
                    {
                        CompareLspFTLRow1 clf = new CompareLspFTLRow1();
                        clf.InstanceGroupId = 1;
                        clf.InstanceId = 1;
                        clf.VehicleTypeSno = obj.Vehicles[0].VehicleSno;
                        clf.RowId = trc.RowId;
                        clf.SubId = trc.SubId;
                        clf.ItemId = trc.ItemId;
                        clf.ItemSno = trc.ItemSno;
                        clf.OrderSno = trc.OrderSno;
                        clf.Height = trc.Height;
                        clf.Width = trc.Width;
                        clf.Length = trc.Length;
                        clf.Qty = trc.Qty;
                        clf.BalQty = trc.BalQty;
                        clf.TakenWeight = trc.TakenWeight;
                        clf.TakenVolume = trc.TakenVolume;
                        clf.BalWeight = trc.BalWeight;
                        clf.BalVolume = trc.BalVolume;
                        clf.BalHeight = trc.BalHeight;//
                        clf.BalWidth = trc.BalWidth;//
                        clf.BalLength = trc.BalLength;//
                        clf.Level = trc.Level;
                        clf.Column = trc.Column;
                        clf.WayofPutting = trc.WayofPutting;
                        clf.Priority = trc.Priority;
                        // clf.SectionOrder = trc.SectionOrder;//
                        clf.OrginX = trc.OrginX;
                        clf.OrginY = trc.OrginY;
                        CompareLspFTLRows.Add(clf);
                    }
                }


                TlopImagePath = System.Configuration.ConfigurationManager.ConnectionStrings["FileUpload"].ConnectionString + "\\TlopDrawing\\" + Guid.NewGuid().ToString() + ".pdf";
                File.WriteAllBytes(TlopImagePath, SequencePDf);

            }
            catch (Exception eae) { }




            return TlopImagePath;

        }


        


        public SysExecelDetails SequenceExcelDownload(SeqDet obj1)
        {

            SysExecelDetails  ObjCompareLspFTLRows = new SysExecelDetails();

            List<SqlParameter> objListOfsqlParameters = new List<SqlParameter>();

            DataTable dt = new DataTable();
            dt = obj1.ObjSeqDet.ToDataTable<CompareLspFTLRow>();
            dt.Columns.Remove("SectionOrder");
            SqlParameter paramVehicleSno = new SqlParameter("@VehicleSno", obj1.VehicleSno);
            paramVehicleSno.SqlDbType = SqlDbType.Int;
            objListOfsqlParameters.Add(paramVehicleSno);

            SqlParameter paramVehicleInstanceId = new SqlParameter("@VehicleInstanceId", obj1.VehicleInstanceId);
            paramVehicleInstanceId.SqlDbType = SqlDbType.Int;
            objListOfsqlParameters.Add(paramVehicleInstanceId);

            SqlParameter paramindex = new SqlParameter("@index", obj1.index);
            paramindex.SqlDbType = SqlDbType.Int;
            objListOfsqlParameters.Add(paramindex);


            SqlParameter paramUnutilizedVolume = new SqlParameter("@UnutilizedVolume", obj1.UnutilizedVolume);
            paramUnutilizedVolume.SqlDbType = SqlDbType.VarChar;
            objListOfsqlParameters.Add(paramUnutilizedVolume);

            SqlParameter paramUnutilizedWeight = new SqlParameter("@UnutilizedWeight", obj1.UnutilizedWeight);
            paramUnutilizedWeight.SqlDbType = SqlDbType.VarChar;
            objListOfsqlParameters.Add(paramUnutilizedWeight);

            SqlParameter paraWeight = new SqlParameter("@Weight", obj1.Weight);
            paraWeight.SqlDbType = SqlDbType.VarChar;
            objListOfsqlParameters.Add(paraWeight);

            SqlParameter paramVolume = new SqlParameter("@Volume", obj1.Volume);
            paramVolume.SqlDbType = SqlDbType.VarChar;
            objListOfsqlParameters.Add(paramVolume);



            SqlParameter SequenceRepo = new SqlParameter();
            SequenceRepo.ParameterName = "@SequenceDetails";
            SequenceRepo.SqlDbType = SqlDbType.Structured;
            SequenceRepo.Value = dt;
            SequenceRepo.Direction = ParameterDirection.Input;
            objListOfsqlParameters.Add(SequenceRepo);

            if (obj1.typeofWaypoint == "G")
            {
                SqlParameter SequenceRepo1 = new SqlParameter();
                SequenceRepo1.ParameterName = "@WaypointDetails";
                SequenceRepo1.SqlDbType = SqlDbType.Structured;
                SequenceRepo1.Value = obj1.objwaypoint.ToDataTable<waypointSrting2>();
                SequenceRepo1.Direction = ParameterDirection.Input;
                objListOfsqlParameters.Add(SequenceRepo1);
            }

            else
            {
                SqlParameter SequenceRepo1 = new SqlParameter();
                SequenceRepo1.ParameterName = "@WaypointDetails";
                SequenceRepo1.SqlDbType = SqlDbType.Structured;
                SequenceRepo1.Value = obj1.objwaypoint2.ToDataTable<waypointSrting2>();
                SequenceRepo1.Direction = ParameterDirection.Input;
                objListOfsqlParameters.Add(SequenceRepo1);

            }

            SqlParameter grpditems = new SqlParameter();
            grpditems.ParameterName = "@grpitemDetails";
            grpditems.SqlDbType = SqlDbType.Structured;
            grpditems.Value = obj1.grpitem.ToDataTable<groupeditem>();
            grpditems.Direction = ParameterDirection.Input;
            objListOfsqlParameters.Add(grpditems);
            DataSet dataSet = ExecuteCommand(_SeqExcelFetch, objListOfsqlParameters);
            //string result = ds.Tables[0].Rows[0][0].ToString();

            ObjCompareLspFTLRows.CompareLspFTL = dataSet.Tables[0].ToCollection<CompareLspFTLRowXL>();
            ObjCompareLspFTLRows.Vehicletype = dataSet.Tables[1].ToCollection<Vehicletypedetails>();

            return ObjCompareLspFTLRows;
        }


        public ExecelDetails SequenceExcelDownload1(ManualSeqDet obj1)
        {

            // List<ExecelDetails> ObjCompareLspFTLRows = new List<ExecelDetails>();

            ExecelDetails ExecelD = new ExecelDetails();

            List<SqlParameter> objListOfsqlParameters = new List<SqlParameter>();

            DataTable dt = new DataTable();
            dt = obj1.ObjSeqDet.ToDataTable<CompareLspFTLRow>();
            dt.Columns.Remove("SectionOrder");
            SqlParameter paramVehicleSno = new SqlParameter("@Vehicletype", obj1.Vehicletype);
            paramVehicleSno.SqlDbType = SqlDbType.VarChar;
            objListOfsqlParameters.Add(paramVehicleSno);


            //SqlParameter paramVehicaltypeSno = new SqlParameter("@VehicaltypeSno", obj1.VehicaltypeSno);
            //paramVehicaltypeSno.SqlDbType = SqlDbType.VarChar;
            //objListOfsqlParameters.Add(paramVehicaltypeSno);


            SqlParameter paramVolume = new SqlParameter("@Volume", obj1.Volume);
            paramVolume.SqlDbType = SqlDbType.VarChar;
            objListOfsqlParameters.Add(paramVolume);

            SqlParameter paramCarringCapacity = new SqlParameter("@CarringCapacity", obj1.CarringCapacity);
            paramCarringCapacity.SqlDbType = SqlDbType.VarChar;
            objListOfsqlParameters.Add(paramCarringCapacity);

            SqlParameter paramLength = new SqlParameter("@Length", obj1.Length);
            paramLength.SqlDbType = SqlDbType.VarChar;
            objListOfsqlParameters.Add(paramLength);

            SqlParameter paramBreadth = new SqlParameter("@Breadth", obj1.Breadth);
            paramBreadth.SqlDbType = SqlDbType.VarChar;
            objListOfsqlParameters.Add(paramBreadth);

            SqlParameter paramHeight = new SqlParameter("@Height", obj1.Height);
            paramHeight.SqlDbType = SqlDbType.VarChar;
            objListOfsqlParameters.Add(paramHeight);

            SqlParameter paramLoadedVolume = new SqlParameter("@LoadedVolume", obj1.LoadedVolume);
            paramLoadedVolume.SqlDbType = SqlDbType.VarChar;
            objListOfsqlParameters.Add(paramLoadedVolume);

            SqlParameter paramLeftoverVolume = new SqlParameter("@LeftoverVolume", obj1.LeftoverVolume);
            paramLeftoverVolume.SqlDbType = SqlDbType.VarChar;
            objListOfsqlParameters.Add(paramLeftoverVolume);


            SqlParameter paramLoadedVolumePercentage = new SqlParameter("@LoadedVolumePercentage", obj1.LoadedVolumePercentage);
            paramLoadedVolumePercentage.SqlDbType = SqlDbType.VarChar;
            objListOfsqlParameters.Add(paramLoadedVolumePercentage);

            SqlParameter paramLeftoverVolumePercentage = new SqlParameter("@LeftoverVolumePercentage", obj1.LeftoverVolumePercentage);
            paramLeftoverVolumePercentage.SqlDbType = SqlDbType.VarChar;
            objListOfsqlParameters.Add(paramLeftoverVolumePercentage);

            SqlParameter paramLoadedWeightt = new SqlParameter("@LoadedWeight", obj1.LoadedWeight);
            paramLoadedWeightt.SqlDbType = SqlDbType.VarChar;
            objListOfsqlParameters.Add(paramLoadedWeightt);

            SqlParameter paramLeftoverWeight = new SqlParameter("@LeftoverWeight", obj1.LeftoverWeight);
            paramLeftoverWeight.SqlDbType = SqlDbType.VarChar;
            objListOfsqlParameters.Add(paramLeftoverWeight);

            SqlParameter paramLoadedWeightPercentaget = new SqlParameter("@LoadedWeightPercentage", obj1.LoadedWeightPercentage);
            paramLoadedWeightPercentaget.SqlDbType = SqlDbType.VarChar;
            objListOfsqlParameters.Add(paramLoadedWeightPercentaget);


            SqlParameter paramLeftoverWeightPercentage = new SqlParameter("@LeftoverWeightPercentage", obj1.LeftoverWeightPercentage);
            paramLeftoverWeightPercentage.SqlDbType = SqlDbType.VarChar;
            objListOfsqlParameters.Add(paramLeftoverWeightPercentage);

            SqlParameter paramVehicleInstanceId = new SqlParameter("@VehicleInstanceId", obj1.VehicleInstanceId);
            paramVehicleInstanceId.SqlDbType = SqlDbType.Int;
            objListOfsqlParameters.Add(paramVehicleInstanceId);

            //SqlParameter paramVehicleLength = new SqlParameter("@VehicleInstanceId", obj1.Length);
            //paramVehicleLength.SqlDbType = SqlDbType.Int;
            //paramVehicleLength.Add(paramVehicleLength);

            SqlParameter paramindex = new SqlParameter("@index", obj1.index);
            paramindex.SqlDbType = SqlDbType.Int;
            objListOfsqlParameters.Add(paramindex);

            SqlParameter SequenceRepo = new SqlParameter();
            SequenceRepo.ParameterName = "@SequenceDetails";
            SequenceRepo.SqlDbType = SqlDbType.Structured;
            SequenceRepo.Value = dt;
            SequenceRepo.Direction = ParameterDirection.Input;
            objListOfsqlParameters.Add(SequenceRepo);

            SqlParameter SequenceRepo1 = new SqlParameter();
            SequenceRepo1.ParameterName = "@WaypointDetails";
            SequenceRepo1.SqlDbType = SqlDbType.Structured;
            SequenceRepo1.Value = obj1.objwaypoint.ToDataTable<waypointSrting2>();
            SequenceRepo1.Direction = ParameterDirection.Input;
            objListOfsqlParameters.Add(SequenceRepo1);
            //try
            //{
                SqlParameter grpditems = new SqlParameter();
                grpditems.ParameterName = "@grpitemDetails";
                grpditems.SqlDbType = SqlDbType.Structured;
                grpditems.Value = obj1.grpitem.ToDataTable<groupeditem>();
                grpditems.Direction = ParameterDirection.Input;
                objListOfsqlParameters.Add(grpditems);
                DataSet dataSet = ExecuteCommand(_ManualSeqExcelFetch, objListOfsqlParameters);
                ExecelD.ManualCompareLsp = dataSet.Tables[0].ToCollection<ManualCompareLspFTLRowXL>();
                ExecelD.Vehicletypedet = dataSet.Tables[1].ToCollection<Vehicletypedetails>();
                return ExecelD;
            //}
            //catch (Exception eae) { }
        }







    }
}