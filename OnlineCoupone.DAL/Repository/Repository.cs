using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using OnlineCoupone.DAL.Helper;
using OnlineCoupone.Model.ModelDB;

namespace OnlineCoupone.DAL.Repository
{
    public class Repository
    {

        public Repository()
        {
            
        }
        #region Regions
        public List<Region> GetAllRegions()
        {
            try
            {
                var results = PostgreSQLHelper_Policlinic.ExecuteSelectCommand("\"RegionTable\"",
                    CommandType.TableDirect);
                var toReturn = new List<Region>();
                for (var i = 0; i < results.Rows.Count; i++)
                {
                    toReturn.Add(new Region()
                    {
                        RegionId = results.Rows[i].Field<int>("RegionId"),
                        Name = results.Rows[i].Field<string>("Name")
                    });
                }
                return toReturn;
            }
            catch (Exception exception)
            {
                return new List<Region>();
            }
        }

        public Region GetRegionById(int regionId)
        {
            try
            {
                const string query = "SELECT * FROM \"RegionTable\" WHERE \"RegionId\" = @RegionId";
                var parameters = new List<NpgsqlParameter>()
                {
                    new NpgsqlParameter("@RegionId", regionId)
                };
                var results = PostgreSQLHelper_Policlinic.ExecuteParamerizedSelectCommand(query, CommandType.Text,
                    parameters.ToArray());
                if (results.Rows.Count == 0)
                {
                    return null;
                }
                return new Region()
                {
                    Name = results.Rows[0].Field<string>("Name"),
                    RegionId = results.Rows[0].Field<int>("RegionId")
                };
            }
            catch (Exception exception)
            {
                return null;
            }
        }
#endregion

        #region Policlinics
        public List<Policlinic> GetPoliclinicsByRegionId(int regionId)
        {
            try
            {
                var query = "SELECT * FROM \"PoliclinicTable\" WHERE \"RegionId\" = @RegionId";
                var parameters = new List<NpgsqlParameter>()
                {
                    new NpgsqlParameter("@RegionId", regionId)
                };
                var results = PostgreSQLHelper_Policlinic.ExecuteParamerizedSelectCommand(query, CommandType.Text,
                    parameters.ToArray());
                var toReturn = new List<Policlinic>();
                for (var i = 0; i < results.Rows.Count; i++)
                {
                    toReturn.Add(new Policlinic()
                    {
                        PoliclinicId = results.Rows[i].Field<int>("PoliclinicId"),
                        Title = results.Rows[i].Field<string>("Title"),
                        Region = GetRegionById(results.Rows[i].Field<int>("RegionId"))
                    });
                }
                return toReturn;
            }
            catch (Exception exception)
            {
                return new List<Policlinic>();
            }
        }

        public Policlinic GetPoliclinicById(int policlinicId)
        {
            try
            {
                var query = "SELECT * FROM \"PoliclinicTable\" WHERE \"PoliclinicId\" = @PoliclinicId";
                var parameters = new List<NpgsqlParameter>()
                {
                    new NpgsqlParameter("@PoliclinicId", policlinicId)
                };
                var results = PostgreSQLHelper_Policlinic.ExecuteParamerizedSelectCommand(query, CommandType.Text,
                    parameters.ToArray());
                if (results.Rows.Count == 0)
                {
                    return null;
                }
                return new Policlinic()
                {
                    PoliclinicId = results.Rows[0].Field<int>("PoliclinicId"),
                    Title = results.Rows[0].Field<string>("Title"),
                    Region = GetRegionById(results.Rows[0].Field<int>("RegionId"))
                };
            }
            catch (Exception exception)
            {
                return new Policlinic();
            }
        }
        #endregion

        #region Specialization
        public List<Specialization> GetAllSpecializations()
        {
            try
            {
                var results = PostgreSQLHelper_Policlinic.ExecuteSelectCommand("\"SpecializationTable\"",
                    CommandType.TableDirect);
                var toReturn = new List<Specialization>();
                for (var i = 0; i < results.Rows.Count; i++)
                {
                    toReturn.Add(new Specialization()
                    {
                        Name = results.Rows[i].Field<string>("Name"),
                        SpecializationId = results.Rows[i].Field<int>("SpecializationId")
                    });
                }
                return toReturn;
            }
            catch (Exception exception)
            {
                return new List<Specialization>();
            }
        }

        public Specialization GetSpecializationById(int specializationId)
        {
            try
            {
                var query = "SELECT * FROM \"SpecializationTable\" WHERE \"SpecializationId\" = @SpecializationId";
                var parameters = new List<NpgsqlParameter>()
                {
                    new NpgsqlParameter("@SpecializationId", specializationId)
                };
                var results = PostgreSQLHelper_Policlinic.ExecuteParamerizedSelectCommand(query, CommandType.Text,
                    parameters.ToArray());
                if (results.Rows.Count == 0)
                {
                    return null;
                }
                return new Specialization()
                {
                    SpecializationId = results.Rows[0].Field<int>("SpecializationId"),
                    Name = results.Rows[0].Field<string>("Name")
                };
            }
            catch (Exception exception)
            {
                return new Specialization();
            }
        }

        public int AddSpecialization(Specialization specialization)
        {
            try
            {
                var query = "INSERT INTO \"SpecializationTable\" VALUES(default, @Name) RETURNING \"SpecializationId\"";
                var parameters = new List<NpgsqlParameter>()
                {
                    new NpgsqlParameter("@Name", specialization.Name)
                };
                var results = PostgreSQLHelper_Policlinic.ExecuteParamerizedSelectCommand(query, CommandType.Text,
                    parameters.ToArray());
                return results.Rows.Count > 0 ? int.Parse(results.Rows[0][0].ToString()) : -1;
            }
            catch (Exception exception)
            {
                return -1;
            }
        }

        #endregion

        #region Doctors

        public List<Doctor> GetDoctorsBySpecializationId(int specializationId)
        {
            try
            {
                var query = "SELECT * FROM \"DoctorTable\" WHERE \"SpecializationId\" = @SpecializationId";
                var parameters = new List<NpgsqlParameter>()
                {
                    new NpgsqlParameter("@SpecializationId", specializationId)
                };
                var results = PostgreSQLHelper_Policlinic.ExecuteParamerizedSelectCommand(query, CommandType.Text,
                    parameters.ToArray());
                var toReturn = new List<Doctor>();
                for (var i = 0; i < results.Rows.Count; i++)
                {
                    toReturn.Add(new Doctor()
                    {
                        DoctorId = results.Rows[i].Field<int>("DoctorId"),
                        Fio = results.Rows[i].Field<string>("FIO"),
                        Policlinic = GetPoliclinicById(results.Rows[i].Field<int>("PoliclinicId")),
                        Specialization = GetSpecializationById(results.Rows[i].Field<int>("SpecializationId"))
                    });
                }
                return toReturn;
            }
            catch (Exception exception)
            {
                return new List<Doctor>();
            }
        }

        public Doctor GetDoctorById(int doctorId)
        {
            try
            {
                const string query = "SELECT * FROM \"DoctorTable\" WHERE \"DoctorId\" = @DoctorId";
                var parameters = new List<NpgsqlParameter>()
                {
                    new NpgsqlParameter("@DoctorId", doctorId)
                };
                var results = PostgreSQLHelper_Policlinic.ExecuteParamerizedSelectCommand(query, CommandType.Text,
                    parameters.ToArray());
                if (results.Rows.Count == 0)
                {
                    return null;
                }
                return new Doctor()
                {
                    DoctorId = results.Rows[0].Field<int>("DoctorId"),
                    Fio = results.Rows[0].Field<string>("FIO"),
                    Policlinic = GetPoliclinicById(results.Rows[0].Field<int>("PoliclinicId")),
                    Specialization = GetSpecializationById(results.Rows[0].Field<int>("SpecializationId"))
                };
            }
            catch (Exception exception)
            {
                return new Doctor();
            }
        }

        #endregion

        #region AvailableTime

        public List<AvailableTime> GetAvailableTimesByDoctorId(int doctorId)
        {
            try
            {
                var query = "SELECT * FROM \"AvailableTimeTable\" WHERE \"DoctorId\" = @DoctorId AND \"PatientId\" is null";
                var parameters = new List<NpgsqlParameter>()
                {
                    new NpgsqlParameter("@DoctorId", doctorId)
                };
                var results = PostgreSQLHelper_Policlinic.ExecuteParamerizedSelectCommand(query, CommandType.Text,
                    parameters.ToArray());
                var toReturn = new List<AvailableTime>();
                for (var i = 0; i < results.Rows.Count; i++)
                {
                    toReturn.Add(new AvailableTime()
                    {
                        AvailableTimeId = results.Rows[i].Field<int>("AvailableTimeId"),
                        Patient = results.Rows[i].Field<int?>("PatientId") == null ? null : GetPatientById(results.Rows[i].Field<int>("PatientId")),
                        Doctor = GetDoctorById(results.Rows[i].Field<int>("DoctorId")),
                        Time = results.Rows[i].Field<DateTime>("Time")
                    });
                }
                return toReturn;
            }
            catch (Exception exception)
            {
                return new List<AvailableTime>();
            }
        }

        public bool SetUnusedAvailableTimeById(int availableTimeId)
        {
            try
            {
                var query = "UPDATE \"AvailableTimeTable\" SET \"PatientId\" = null WHERE \"AvailableTimeId\" = @AvailableTimeId";
                var parameters = new List<NpgsqlParameter>()
                {
                    new NpgsqlParameter("@AvailableTimeId", availableTimeId)
                };
                return PostgreSQLHelper_Policlinic.ExecuteNonQuery(query, CommandType.Text,
                    parameters.ToArray());
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SetUsedAvailableTimeByTime(DateTime time, int patientId)
        {
            try
            {
                var query = "UPDATE \"AvailableTimeTable\" SET \"PatientId\" = @PatientId WHERE \"Time\" = @Time";
                var parameters = new List<NpgsqlParameter>()
                {
                    new NpgsqlParameter("@Time", time),
                    new NpgsqlParameter("@PatientId", patientId)
                };
                return PostgreSQLHelper_Policlinic.ExecuteNonQuery(query, CommandType.Text,
                    parameters.ToArray());
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public AvailableTime GetAvailableTimeByTime(DateTime time)
        {
            try
            {
                var query = "SELECT * FROM \"AvailableTimeTable\" WHERE \"Time\" = @Time";
                var parameters = new List<NpgsqlParameter>()
                {
                    new NpgsqlParameter("@Time", time)
                };
                var results = PostgreSQLHelper_Policlinic.ExecuteParamerizedSelectCommand(query, CommandType.Text,
                    parameters.ToArray());
                if (results.Rows.Count == 0)
                {
                    return null;
                }
                return new AvailableTime()
                {
                    AvailableTimeId = results.Rows[0].Field<int>("AvailableTimeId"),
                    Patient = results.Rows[0].Field<int?>("PatientId") == null ? null : GetPatientById(results.Rows[0].Field<int>("PatientId")),
                    Doctor = GetDoctorById(results.Rows[0].Field<int>("DoctorId")),
                    Time = results.Rows[0].Field<DateTime>("Time")
                };
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public AvailableTime GetAvailableTimeById(int availableTimeId)
        {
            try
            {
                var query = "SELECT * FROM \"AvailableTimeTable\" WHERE \"AvailableTimeId\" = @AvailableTimeId";
                var parameters = new List<NpgsqlParameter>()
                {
                    new NpgsqlParameter("@AvailableTimeId", availableTimeId)
                };
                var results = PostgreSQLHelper_Policlinic.ExecuteParamerizedSelectCommand(query, CommandType.Text,
                    parameters.ToArray());
                if (results.Rows.Count == 0)
                {
                    return null;
                }
                return new AvailableTime()
                {
                    AvailableTimeId = results.Rows[0].Field<int>("AvailableTimeId"),
                    Patient = results.Rows[0].Field<int?>("PatientId") == null ? null : GetPatientById(results.Rows[0].Field<int>("PatientId")),
                    Doctor = GetDoctorById(results.Rows[0].Field<int>("DoctorId")),
                    Time = results.Rows[0].Field<DateTime>("Time")
                };
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        #endregion

        #region Patient

        public Patient GetPatientById(int patientId)
        {
            try
            {
                var query = "SELECT * FROM \"PatientTable\" WHERE \"PatientId\" = @PatientId";
                var parameters = new List<NpgsqlParameter>()
                {
                    new NpgsqlParameter("@PatientId", patientId)
                };
                var results = PostgreSQLHelper_Policlinic.ExecuteParamerizedSelectCommand(query, CommandType.Text,
                    parameters.ToArray());
                if (results.Rows.Count == 0)
                {
                    return null;
                }
                return new Patient()
                {
                    Address = results.Rows[0].Field<string>("Address"),
                    Birthday = results.Rows[0].Field<DateTime>("BirthDay"),
                    FirstName = results.Rows[0].Field<string>("Name"),
                    LastName = results.Rows[0].Field<string>("LastName"),
                    Patronymic = results.Rows[0].Field<string>("Patronymic")
                };
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int IsPatientExists(Patient patient)
        {
            try
            {
                var query = "SELECT \"PatientId\" FROM \"PatientTable\" WHERE \"Name\" = @Name AND \"LastName\" = @LastName AND \"Patronymic\" = @Patronymic AND \"BirthDay\" = @BirthDay AND \"Address\" = @Address";
                var parameters = new List<NpgsqlParameter>()
                {
                    new NpgsqlParameter("@Name", patient.FirstName),
                    new NpgsqlParameter("@LastName", patient.LastName),
                    new NpgsqlParameter("@Patronymic", patient.Patronymic),
                    new NpgsqlParameter("@BirthDay", patient.Birthday),
                    new NpgsqlParameter("@Address", patient.Address)
                };
                var results = PostgreSQLHelper_Policlinic.ExecuteParamerizedSelectCommand(query, CommandType.Text,
                    parameters.ToArray());
                return results.Rows.Count != 0 ? results.Rows[0].Field<int>("PatientId") : -1;
            }
            catch (Exception exception)
            {
                return -1;
            }
        }

        #endregion

        #region Order

        public int AddOrder(int patientId, int doctorId, int availableTimeId)
        {
            try
            {
                const string query = "INSERT INTO \"VisitHistoryTable\" VALUES(default, @PatientId, @DoctorId, @AvailableTimeId) RETURNING \"VisitHistoryId\"";
                var parameters = new List<NpgsqlParameter>()
                {
                    new NpgsqlParameter("@PatientId", patientId),
                    new NpgsqlParameter("@DoctorId", doctorId),
                    new NpgsqlParameter("@AvailableTimeId", availableTimeId),
                };
                var res = PostgreSQLHelper_OnlineSystem.ExecuteParamerizedSelectCommand(query, CommandType.Text,
                    parameters.ToArray());
                return res.Rows.Count != 0 ? res.Rows[0].Field<int>("VisitHistoryId") : -1;
            }
            catch (Exception exception)
            {
                return -1;
            }
        }

        #endregion

#region VisitHistory
        public VisitHistory GetVisitHistoryById(int visitHistoryId)
        {
            try
            {
                var query = "SELECT * FROM \"VisitHistoryTable\" WHERE \"VisitHistoryId\" = @VisitHistoryId";
                var parameters = new List<NpgsqlParameter>()
                {
                    new NpgsqlParameter("@VisitHistoryId", visitHistoryId)
                };
                var results = PostgreSQLHelper_OnlineSystem.ExecuteParamerizedSelectCommand(query, CommandType.Text,
                    parameters.ToArray());
                if (results.Rows.Count == 0)
                {
                    return null;
                }
                return new VisitHistory()
                {
                    AvailableTime = GetAvailableTimeById(results.Rows[0].Field<int>("AvailableTimeId")),
                    Doctor = GetDoctorById(results.Rows[0].Field<int>("DoctorId")),
                    Patient = GetPatientById(results.Rows[0].Field<int>("PatientId")),
                    VisitHistoryId = results.Rows[0].Field<int>("VisitHistoryId")
                };
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<VisitHistory> GetAllVisitHistoriesByPatientId(int patientId)
        {
            try
            {
                var query = "SELECT * FROM \"VisitHistoryTable\" WHERE \"PatientId\" = @PatientId";
                var parameters = new List<NpgsqlParameter>()
                {
                    new NpgsqlParameter("@PatientId", patientId)
                };
                var results = PostgreSQLHelper_OnlineSystem.ExecuteParamerizedSelectCommand(query, CommandType.Text,
                    parameters.ToArray());
                var toReturn = new List<VisitHistory>();
                for (var i = 0; i < results.Rows.Count; i++)
                {
                    toReturn.Add(new VisitHistory()
                    {
                        AvailableTime = GetAvailableTimeById(results.Rows[i].Field<int>("AvailableTimeId")),
                        Doctor = GetDoctorById(results.Rows[i].Field<int>("DoctorId")),
                        Patient = GetPatientById(results.Rows[i].Field<int>("PatientId")),
                        VisitHistoryId = results.Rows[i].Field<int>("VisitHistoryId")
                    });
                }
                return toReturn;
            }
            catch (Exception)
            {
                return new List<VisitHistory>();
            }
        }

        public List<HomeVisitHistory> GetAllHomeVisitHistoriesByPatientId(int patientId)
        {
            try
            {
                var query = "SELECT * FROM \"HomeVisitHistoryTable\" WHERE \"PatientId\" = @PatientId";
                var parameters = new List<NpgsqlParameter>()
                {
                    new NpgsqlParameter("@PatientId", patientId)
                };
                var results = PostgreSQLHelper_OnlineSystem.ExecuteParamerizedSelectCommand(query, CommandType.Text,
                    parameters.ToArray());
                var toReturn = new List<HomeVisitHistory>();
                for (var i = 0; i < results.Rows.Count; i++)
                {
                    toReturn.Add(new HomeVisitHistory()
                    {
                        Policlinic = GetPoliclinicById(results.Rows[i].Field<int>("PoliclinicId")),
                        Date = results.Rows[i].Field<DateTime>("Date"),
                        Patient = GetPatientById(results.Rows[i].Field<int>("PatientId")),
                        HomeVisitHistoryId = results.Rows[i].Field<int>("HomeVisitHistoryId")
                    });
                }
                return toReturn;
            }
            catch (Exception)
            {
                return new List<HomeVisitHistory>();
            }
        }

        public List<VisitHistory> GetAllVisitsByPateientIdAndPoliclinicId(int patientId, int policilnicId)
        {
            try
            {
                var allHistories = GetAllVisitHistoriesByPatientId(patientId);
                return allHistories.Where(t => t.Doctor.Policlinic.PoliclinicId == policilnicId).ToList();
            }
            catch (Exception exception)
            {
                return new List<VisitHistory>();
            }
        }

        public List<HomeVisitHistory> GetHomeVisitHistoriesByPatientIdAndPoliclinicId(int patientId, int policlinicId)
        {
            try
            {
                var allHistories = GetAllHomeVisitHistoriesByPatientId(patientId);
                return allHistories.Where(t => t.Policlinic.PoliclinicId == patientId).ToList();
            }
            catch (Exception exception)
            {
                return new List<HomeVisitHistory>();
            }
        }

        public bool DeleteHomeVisitHistory(int homeVisitHistoryId)
        {
            try
            {
                var query = "DELETE FROM \"HomeVisitHistoryTable\" WHERE \"HomeVisitHistoryId\" = @HomeVisitHistoryId";
                var parameters = new List<NpgsqlParameter>()
                {
                    new NpgsqlParameter("@HomeVisitHistoryId", homeVisitHistoryId)
                };
                return PostgreSQLHelper_OnlineSystem.ExecuteNonQuery(query, CommandType.Text, parameters.ToArray());
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public bool DeleteVisitHistory(int visitHistoryId)
        {
            try
            {
                var query = "DELETE FROM \"VisitHistoryTable\" WHERE \"VisitHistoryId\" = @VisitHistoryId";
                var parameters = new List<NpgsqlParameter>()
                {
                    new NpgsqlParameter("@VisitHistoryId", visitHistoryId)
                };
                return PostgreSQLHelper_OnlineSystem.ExecuteNonQuery(query, CommandType.Text, parameters.ToArray());
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public int AddHomeVisitHistory(HomeVisitHistory history)
        {
            try
            {
                var query = "INSERT INTO \"HomeVisitHistoryTable\" VALUES(default, @PatientId, @Date, @PoliclinicId) RETURNING \"HomeVisitHistoryId\"";
                var parameters = new List<NpgsqlParameter>()
                {
                    new NpgsqlParameter("@PatientId", IsPatientExists(history.Patient)),
                    new NpgsqlParameter("@Date", history.Date),
                    new NpgsqlParameter("@PoliclinicId", history.Policlinic.PoliclinicId)
                };
                var res = PostgreSQLHelper_OnlineSystem.ExecuteParamerizedSelectCommand(query, CommandType.Text, parameters.ToArray());
                return res.Rows.Count == 0 ? -1 : res.Rows[0].Field<int>("HomeVisitHistoryId");
            }
            catch (Exception exception)
            {
                return -1;
            }
        }

        public HomeVisitHistory GetHomeVisitHistoryById(int homeVisitHistoryId)
        {
            try
            {
                var query = "SELECT * FROM \"HomeVisitHistoryTable\" WHERE \"HomeVisitHistoryId\" = @HomeVisitHistoryId";
                var parameters = new List<NpgsqlParameter>()
                {
                    new NpgsqlParameter("@HomeVisitHistoryId", homeVisitHistoryId)
                };
                var res = PostgreSQLHelper_OnlineSystem.ExecuteParamerizedSelectCommand(query, CommandType.Text,
                    parameters.ToArray());
                if (res.Rows.Count == 0)
                {
                    return null;
                }
                return new HomeVisitHistory()
                {
                    Policlinic = GetPoliclinicById(res.Rows[0].Field<int>("PoliclinicId")),
                    Date = res.Rows[0].Field<DateTime>("Date"),
                    Patient = GetPatientById(res.Rows[0].Field<int>("PatientId")),
                    HomeVisitHistoryId = res.Rows[0].Field<int>("HomeVisitHistoryId")
                };
            }
            catch (Exception)
            {
                return null;
            }
        }

#endregion
    }
}
 