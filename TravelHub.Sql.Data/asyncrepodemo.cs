using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TravelHub.Sql.Data
{
    
}
//{
//    public class LaborRecordSheetRepositoryAsync : ILaborRecordSheetRepositoryAsync
//    {
//        public static readonly log4net.ILog Log = LogManager.GetLogger(typeof(LaborRecordSheetRepositoryAsync));

//        public async Task AddAsync(LaborRecordSheet laborRecord)
//        {
//            using (var db = new DynamicsEditContext())
//            {
//                var utcTime = DateTimeUtils.GetUnixTimeNowMillis();
//                laborRecord.TimeSheetKey = utcTime;
//                db.LaborRecordSheet.Add(laborRecord);
//                var result = await db.SaveChangesAsync();
//            }
//        }

//        public async Task AddAsync(IList<LaborRecordSheet> laborRecords)
//        {
//            //todo might have problem when deleted from android and didn't update it to database
//            //error another problem might be hours are changed before submit
//            using (var db = new DynamicsEditContext())
//            {
//                var utcTime = DateTimeUtils.GetUnixTimeNowMillis();
//                foreach (var record in laborRecords)
//                {
//                    var existRecord = db.LaborRecordSheet.SingleOrDefault(
//                        ret =>
//                            ret.ProjectID_FK == record.ProjectID_FK && ret.JobDate == record.JobDate &&
//                            ret.Hours == record.Hours && ret.EmpNo == record.EmpNo);
//                    if (existRecord == null)
//                    {
//                        record.TimeSheetKey = utcTime;
//                        utcTime++;
//                        db.LaborRecordSheet.Add(record);
//                        var result = await db.SaveChangesAsync();
//                    }
//                }
//                //db.LaborRecordSheet.AddRange(laborRecords);
//                //var result = await db.SaveChangesAsync();
//            }
//        }

//        public async Task<bool> FormatLaborRecordProjectId()
//        {
//            using (var db = new DynamicsEditContext())
//            {
//                var result = db.LaborRecordSheet.Where(_ => _.ProjectID_FK != null);
//                if (result != null)
//                {
//                    foreach (var record in result)
//                    {
//                        record.ProjectID_FK = ProjectIdUtils.GetDBFormatProjectId(record.ProjectID_FK);
//                    }
//                    var changes = await db.SaveChangesAsync();
//                    return true;
//                }
//                else
//                {
//                    return false;
//                }
//            }
//        }

//        public IEnumerable<LaborRecordSheet> GetLaborDataByBranchAndSalesCode(string branch, string salesCode, long startTime, long endTime)
//        {
//            using (var db = new DynamicsEditContext())
//            {
//                var startDate = DateTimeUtils.DateTimeFromUnixTimeMillis(startTime);
//                var endDate = DateTimeUtils.DateTimeFromUnixTimeMillis(endTime);
//                var result = db.LaborRecordSheet.Where(_ => _.Branch.Contains(branch) && _.ProjectID_FK.EndsWith(salesCode) && _.JobDate > startDate && _.JobDate <= endDate).ToList();
//                return result;
//            }
//        }

//        public async Task<bool> AddAndUpdateLaborRecord(LaborRecordSheet labor, long sheetKey, decimal hours)
//        {
//            using (var db = new DynamicsEditContext())
//            {
//                //check if this record has been splitted yet.
//                var parentSheet = db.LaborRecordSheet.SingleOrDefault(_ => _.ParentSheetKey == sheetKey);
//                if (parentSheet != null)
//                    return false;
//                var result = db.LaborRecordSheet.SingleOrDefault(_ => _.TimeSheetKey == sheetKey);
//                if (result != null)
//                {
//                    result.Hours = labor.Hours - hours;
//                    result.IsSplit = "TRUE";
//                    labor.Hours = hours;
//                    labor.EarningCode = "002";
//                    labor.TimeSheetKey = DateTimeUtils.GetUnixTimeNowMillis();
//                    labor.ParentSheetKey = sheetKey;
//                    db.LaborRecordSheet.Add(labor);
//                    var changes = await db.SaveChangesAsync();
//                    return true;
//                }
//                else
//                {
//                    return false;
//                }
//                //db.LaborRecordSheet.Add(laborRecord);
//                //var result = await db.SaveChangesAsync();
//            }
//            //throw new NotImplementedException();
//        }

//        public async Task<bool> EditLaborRecord(LaborRecordSheet labor, long sheetKey, decimal hours)
//        {
//            using (var db = new DynamicsEditContext())
//            {
//                var result = db.LaborRecordSheet.SingleOrDefault(_ => _.TimeSheetKey == sheetKey);
//                if (result != null)
//                {
//                    result.Hours = hours;
//                    //var changeRet  = db.SaveChanges();
//                    //labor.Hours = hours;
//                    //labor.EarningCode = "002";
//                    //labor.TimeSheetKey = DateTimeUtils.GetUnixTimeNowMillis();
//                    //db.LaborRecordSheet.Add(labor);
//                    var changes = await db.SaveChangesAsync();
//                    return true;
//                }
//                else
//                {
//                    return false;
//                }
//                //db.LaborRecordSheet.Add(laborRecord);
//                //var result = await db.SaveChangesAsync();
//            }
//            //throw new NotImplementedException();
//        }

//        public async Task<IList<LaborRecordSheet>> GetJobLaborCopyByProject(string projectId)
//        {
//            projectId = ProjectIdUtils.GetDBFormatProjectId(projectId);
//            using (var db = new DynamicsEditContext())
//            {
//                try
//                {
//                    var result = await db.LaborRecordSheet.Where(_ => _.ProjectID_FK == projectId).ToListAsync();
//                    return result;
//                }
//                catch (EntityException ex)
//                {
//                    Log.Error(ex.Message);
//                    throw;
//                }
//            }

//        }

//        public async Task<IList<string>> UpdateProjectIdAsync(string oldProjectId, string newProjectId)
//        {
//            var retList = new List<string>();
//            using (var db = new DynamicsEditContext())
//            {
//                oldProjectId = ProjectIdUtils.GetDBFormatProjectId(oldProjectId);
//                var result = db.LaborRecordSheet.Where(_ => _.ProjectID_FK == oldProjectId).ToList();
//                if (result.Count != 0)
//                {
//                    foreach (var record in result)
//                    {
//                        record.ProjectID_FK = ProjectIdUtils.GetDBFormatProjectId(newProjectId);
//                        retList.Add(record.TimeSheetKey.ToString());
//                    }
//                    await db.SaveChangesAsync();
//                    return retList;
//                }
//                return null;
//            }
//        }

//        public async Task<bool> RemoveLabourSheetByProject(MergedLaborData sheet, string currentProjectId)
//        {
//            using (var db = new DynamicsEditContext())
//            {
//                var result = db.LaborRecordSheet.Where(_ => _.ProjectID_FK == currentProjectId).ToList();
//                if (result.Count != 0)
//                {
//                    foreach (var record in result)
//                    {
//                        if (sheet.TimesheetKey.Contains(record.TimeSheetKey.ToString()))
//                        {
//                            record.ProjectID_FK = ProjectIdUtils.GetDBFormatProjectId(sheet.ProjectId);
//                        }
//                    }
//                    await db.SaveChangesAsync();
//                    return true;
//                }
//                return false;
//            }
//        }

//        public async Task<List<LaborRecordSheet>> GetPendingRecordsByBranchAsync(string branch)
//        {
//            using (var db = new DynamicsEditContext())
//            {

//                //var branchCode = ProjectIdUtils.GetLocnCodeFromBranch(branch);
//                if (!string.IsNullOrWhiteSpace(branch))
//                {
//                    var result = await db.LaborRecordSheet.Where(_ =>
//                         _.Branch == branch && _.Status_FK == (short)LaborRecordStatus.Pending).ToListAsync();

//                    return result;
//                }
//                else
//                {
//                    throw new NullReferenceException();
//                }


//            }


//        }

//        public async Task<bool> RejectRecordAsync(long sheetKey)
//        {
//            using (var db = new DynamicsEditContext())
//            {
//                var result = db.LaborRecordSheet.SingleOrDefault(_ => _.TimeSheetKey == sheetKey);
//                if (result != null)
//                {
//                    result.Status_FK = (short)LaborRecordStatus.Rejected;
//                    var changes = await db.SaveChangesAsync();
//                    return true;
//                }
//                else
//                    return false;
//            }
//        }

//        public async Task<LaborRecordSheet> GetOneLaborSpec(long sheetKey)
//        {
//            using (var db = new DynamicsEditContext())
//            {
//                var result = db.LaborRecordSheet.SingleOrDefault(_ => _.TimeSheetKey == sheetKey);
//                if (result != null)
//                {
//                    return result;
//                }
//                else
//                    return null;
//            }
//        }

//        public async Task<bool> UpdateRecordAsync(long sheetKey, decimal hours)
//        {
//            using (var db = new DynamicsEditContext())
//            {
//                var result = db.LaborRecordSheet.SingleOrDefault(_ => _.TimeSheetKey == sheetKey);
//                if (result != null)
//                {
//                    result.Hours = hours;
//                    var changes = await db.SaveChangesAsync();
//                    return true;
//                }
//                else
//                    return false;
//            }
//        }

//        public async Task<bool> ApproveRecordById(long sheetKey)
//        {
//            using (var db = new DynamicsEditContext())
//            {
//                var result = db.LaborRecordSheet.SingleOrDefault(_ => _.TimeSheetKey == sheetKey);
//                if (result != null)
//                {
//                    result.Status_FK = (short)LaborRecordStatus.Approved;
//                    var changes = await db.SaveChangesAsync();
//                    return true;
//                }
//                else
//                    return false;
//            }
//        }

//        public async Task<List<LaborRecordSheet>> GetAllApprovedRecordsForLast7Days()
//        {
//            var dateLast7Days = DateTime.UtcNow.AddDays(-7);
//            using (var db = new DynamicsEditContext())
//            {
//                var result = db.LaborRecordSheet.Where(_ => _.Status_FK == (short)LaborRecordStatus.Approved && _.JobDate > dateLast7Days).ToList();
//                return result;
//            }
//        }

//        public async Task<List<LaborRecordSheet>> GetAllPendingRecordsForLast7Days()
//        {
//            var dateLast7Days = DateTime.UtcNow.AddDays(-7);
//            using (var db = new DynamicsEditContext())
//            {
//                var result = db.LaborRecordSheet.Where(_ => _.Status_FK == (short)LaborRecordStatus.Pending && _.JobDate > dateLast7Days).ToList();
//                return result;
//            }
//        }

//        public async Task<List<LaborRecordSheet>> GetAllPendingRecords()
//        {
//            using (var db = new DynamicsEditContext())
//            {
//                var result = db.LaborRecordSheet.Where(_ => _.Status_FK == (short)LaborRecordStatus.Pending).ToList();
//                return result;
//            }
//        }

//        public async Task<bool> ApproveRecordAsync(string projectId, int jobId)
//        {
//            using (var db = new DynamicsEditContext())
//            {
//                projectId = ProjectIdUtils.GetDBFormatProjectId(projectId);
//                var result = db.LaborRecordSheet.Where(_ => _.ProjectID_FK == projectId);
//                if (result != null)
//                {
//                    foreach (var record in result)
//                    {
//                        record.Status_FK = (short)LaborRecordStatus.Approved;
//                    }
//                    var changes = await db.SaveChangesAsync();
//                    return true;
//                }
//                else
//                    return false;
//            }

//        }

//        public async Task<bool> ApproveAllPendingRecordsByBranch(string branch)
//        {
//            if (string.IsNullOrWhiteSpace(branch))
//            {
//                return false;
//            }
//            using (var db = new DynamicsEditContext())
//            {

//                var result = db.LaborRecordSheet.Where(_ => _.Branch == branch && _.Status_FK == (short)LaborRecordStatus.Pending);
//                if (result != null)
//                {
//                    foreach (var record in result)
//                    {
//                        record.Status_FK = (short)LaborRecordStatus.Approved;
//                    }
//                    var changes = await db.SaveChangesAsync();
//                    return true;
//                }
//                else
//                    throw new NullReferenceException();
//            }
//        }

//        public async Task<IList<LaborRecordSheet>> GetAllRecords()
//        {
//            using (var db = new DynamicsEditContext())
//            {
//                var result = db.LaborRecordSheet.ToList();
//                return result;
//            }
//        }
//    }
//}
