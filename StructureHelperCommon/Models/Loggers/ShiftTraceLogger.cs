﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructureHelperCommon.Models.Loggers
{
    public class ShiftTraceLogger : IShiftTraceLogger
    {
        public ITraceLogger Logger { get; set; }
        public int ShiftPriority { get; set; }

        public List<ITraceLoggerEntry> TraceLoggerEntries => Logger.TraceLoggerEntries;
        public ShiftTraceLogger(ITraceLogger logger)
        {
            Logger = logger;
        }
        public ShiftTraceLogger() : this(new TraceLogger())  {  }
        public void AddMessage(string message, TraceLoggerStatuses status = TraceLoggerStatuses.Info, int shiftPrioriry = 0)
        {
            // if status in (fatal, error, warning) they must be kept as they are
            if (status <= TraceLoggerStatuses.Warning)
            {
                Logger.AddMessage(message, status);
            }
            else
            {
                var priority = LoggerService.GetPriorityByStatus(status) + shiftPrioriry;
                this.AddMessage(message, priority);
            }
        }

        public void AddMessage(string message, int priority)
        {
            priority += ShiftPriority;
            Logger.AddMessage(message, priority);
        }

        public IShiftTraceLogger GetSimilarTraceLogger(int shiftPriority = 0)
        {
            var newLogger = new ShiftTraceLogger(Logger)
            {
                ShiftPriority = shiftPriority
            };
            return newLogger;
        }

        public void AddEntry(ITraceLoggerEntry loggerEntry)
        {
            loggerEntry.Priority += ShiftPriority;
            Logger.TraceLoggerEntries.Add(loggerEntry);
        }
    }
}
