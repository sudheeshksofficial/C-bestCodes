using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADOdotnetwebappli.DataAccessingLayer;
using ADOdotnetwebappli.Models;

namespace ADOdotnetwebappli.Controllers
{
    public class ProductController : Controller
    {

        ProductDAL _productDAL = new ProductDAL();  
        // GET: Product
        public ActionResult Index()
        {
            var productlist = _productDAL.GetAllProducts();

            if(productlist.Count == 0)
            {
                TempData["InfoMessage"] = "Currently products not available in the database";

            }



            return View(productlist);


        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var prodlist = _productDAL.GetProductByID(id).FirstOrDefault();
            if (prodlist == null)
            {
                TempData["InfoMessage"] = "There is no deta for the id " + id.ToString();
                return RedirectToAction("Index");
            }
            return View(prodlist);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            bool IsInserted = false;
           
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    IsInserted = _productDAL.InsertProduct(product);
                    TempData["SuccessMessage"] = "product details saved successfully...!!";
                }
                else
                {
                    TempData["ErrorMessage"] = "Unable to save the product details........!";
                }

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"]= ex.Message;
                return View();
            }


        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var products = _productDAL.GetProductByID(id).FirstOrDefault();
            if (products == null)
            {
                TempData["InfoMessage"] = "Product is not available with ID " + id.ToString();
                return RedirectToAction("Index");
            }
            return View(products);
        }

        // POST: Product/Edit/5
        [HttpPost, ActionName("Edit")]
        public ActionResult UpdateProduct(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isUpdated = _productDAL.UpdateProduct(product);
                    if (isUpdated)
                    {
                        TempData["SuccessMessage"] = "Product details updated successfully";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Cant able to update the product ";
                    }
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var product = _productDAL.GetProductByID(id).FirstOrDefault();
                if (product == null)
                {
                    TempData["ErrorMessage"] = "Product is not available with the id" + id.ToString();
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: Product/Delete/5
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmation(int id)
        {
            try
            {
               string result = _productDAL.DeleteProduct(id);

                if (result.Contains("deleted"))
                {
                    TempData["SuccessMessage"] = result;
                }
                else
                {
                    TempData["ErrorMessage"] = result;
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }
    }
}
