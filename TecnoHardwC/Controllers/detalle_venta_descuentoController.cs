using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TecnoHardwC.Models;

namespace TecnoHardwC.Controllers
{
    public class detalle_venta_descuentoController : Controller
    {
        private PaginaEntities db = new PaginaEntities();

        // GET: detalle_venta_descuento
        public ActionResult Index()
        {
            var detalle_venta_descuento = db.detalle_venta_descuento.Include(d => d.articulo).Include(d => d.venta);
            return View(detalle_venta_descuento.ToList());
        }

        // GET: detalle_venta_descuento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalle_venta_descuento detalle_venta_descuento = db.detalle_venta_descuento.Find(id);
            if (detalle_venta_descuento == null)
            {
                return HttpNotFound();
            }
            return View(detalle_venta_descuento);
        }

        // GET: detalle_venta_descuento/Create
        public ActionResult Create()
        {
            ViewBag.idarticulo = new SelectList(db.articulo, "idarticulo", "codigo");
            ViewBag.idventa = new SelectList(db.venta, "idventa", "tipo_comprobante");
            return View();
        }

        // POST: detalle_venta_descuento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "iddetalle_venta,idventa,idarticulo,cantidad,precio,descuento")] detalle_venta_descuento detalle_venta_descuento)
        {
            if (ModelState.IsValid)
            {
                db.detalle_venta_descuento.Add(detalle_venta_descuento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idarticulo = new SelectList(db.articulo, "idarticulo", "codigo", detalle_venta_descuento.idarticulo);
            ViewBag.idventa = new SelectList(db.venta, "idventa", "tipo_comprobante", detalle_venta_descuento.idventa);
            return View(detalle_venta_descuento);
        }

        // GET: detalle_venta_descuento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalle_venta_descuento detalle_venta_descuento = db.detalle_venta_descuento.Find(id);
            if (detalle_venta_descuento == null)
            {
                return HttpNotFound();
            }
            ViewBag.idarticulo = new SelectList(db.articulo, "idarticulo", "codigo", detalle_venta_descuento.idarticulo);
            ViewBag.idventa = new SelectList(db.venta, "idventa", "tipo_comprobante", detalle_venta_descuento.idventa);
            return View(detalle_venta_descuento);
        }

        // POST: detalle_venta_descuento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "iddetalle_venta,idventa,idarticulo,cantidad,precio,descuento")] detalle_venta_descuento detalle_venta_descuento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalle_venta_descuento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idarticulo = new SelectList(db.articulo, "idarticulo", "codigo", detalle_venta_descuento.idarticulo);
            ViewBag.idventa = new SelectList(db.venta, "idventa", "tipo_comprobante", detalle_venta_descuento.idventa);
            return View(detalle_venta_descuento);
        }

        // GET: detalle_venta_descuento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalle_venta_descuento detalle_venta_descuento = db.detalle_venta_descuento.Find(id);
            if (detalle_venta_descuento == null)
            {
                return HttpNotFound();
            }
            return View(detalle_venta_descuento);
        }

        // POST: detalle_venta_descuento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            detalle_venta_descuento detalle_venta_descuento = db.detalle_venta_descuento.Find(id);
            db.detalle_venta_descuento.Remove(detalle_venta_descuento);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
