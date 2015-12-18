//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using OnlineCoupone.Web.Models;

//namespace OnlineCoupone.Web.Repository
//{
//    public class PatientRepository : IDisposable
//    {
//        private ContextName _context;
//        private bool _disposed = false;

//        public PatientRepository(ContextName context)
//        {
//            _context = context;
//        }

//        public void DeletePatient(int patientId)
//        {
//            Patient patient = _context.Patient.Find(patientId);
//            if (patient == null)
//            {
//                throw new ArgumentException();
//            }
//            _context.Patient.Remove(patient);
//        }

//        public Patient GetByID(int patientId)
//        {
//            return _context.Patient.Find(patientId);
//        }

//        public IEnumerable<Patient> Get()
//        {
//            return _context.Patient.ToList();
//        }

//        public void InsertPatient(Patient patient)
//        {
//            _context.Patient.Add(patient);
//        }

//        public void Save()
//        {
//            _context.SaveChanges();
//        }

//        public void UpdatePatient(Patient patient)
//        {
//            _context.Entry(patient).State = System.Data.Entity.EntityState.Modified;
//        }

//        protected virtual void Dispose(bool disposing)
//        {
//            if (!_disposed)
//            {
//                if (disposing)
//                {
//                    _context.Dispose();
//                }
//            }
//            _disposed = true;
//        }

//        public void Dispose()
//        {
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }
//    }
//}