﻿using LezizSofralar.ViewModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace LezizSofralar.Repository
{
    public class RecipesRepository
    {
        public MySqlConnection con;
        //To Handle connection related activities
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["SqlConn"].ToString();
            con = new MySqlConnection(constr);
        }
        //To Add Employee details
        //public void AddRecipe(RecipesListItem objRecipe)
        //{
        //    //Additing the employess
        //    try
        //    {
        //        connection();
        //        con.Open();
        //        con.CreateCommand("AddNewEmpDetails", objRecipe, commandType: CommandType.StoredProcedure);
        //        con.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        ////To view employee details with generic list 
        //public List<EmpModel> GetAllEmployees()
        //{
        //    try
        //    {
        //        connection();
        //        con.Open();
        //        IList<EmpModel> EmpList = SqlMapper.Query<EmpModel>(
        //                          con, "GetEmployees").ToList();
        //        con.Close();
        //        return EmpList.ToList();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        ////To Update Employee details
        //public void UpdateEmployee(EmpModel objUpdate)
        //{
        //    try
        //    {
        //        connection();
        //        con.Open();
        //        con.Execute("UpdateEmpDetails", objUpdate, commandType: CommandType.StoredProcedure);
        //        con.Close();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        ////To delete Employee details
        //public bool DeleteEmployee(int Id)
        //{
        //    try
        //    {
        //        DynamicParameters param = new DynamicParameters();
        //        param.Add("@EmpId", Id);
        //        connection();
        //        con.Open();
        //        con.Execute("DeleteEmpById", param, commandType: CommandType.StoredProcedure);
        //        con.Close();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        //Log error as per your need 
        //        throw ex;
        //    }
        //}
    }
}
