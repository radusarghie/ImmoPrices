﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Immo.Logic.SeedData
{
    public class SequentialGuid
    {
        Guid currentGuid;
        public Guid CurrentGuid
        {
            get
            {
                return currentGuid;
            }
        }

        public SequentialGuid()
        {
            currentGuid = Guid.Empty;
        }

        public SequentialGuid(Guid previousGuid)
        {
            currentGuid = previousGuid;
        }

        public static SequentialGuid operator ++(SequentialGuid sequentialGuid)
        {
            byte[] bytes = sequentialGuid.currentGuid.ToByteArray();
            for (int mapIndex = 0; mapIndex < 16; mapIndex++)
            {
                int bytesIndex = SqlOrderMap[mapIndex];
                bytes[bytesIndex]++;
                if (bytes[bytesIndex] != 0)
                {
                    break; // No need to increment more significant bytes
                }
            }
            sequentialGuid.currentGuid = new Guid(bytes);
            return sequentialGuid;
        }

        private static int[] sqlOrderMap = null;
        private static int[] SqlOrderMap
        {
            get
            {
                if (sqlOrderMap == null)
                {
                    sqlOrderMap = new int[16] {
                    3, 2, 1, 0, 5, 4, 7, 6, 9, 8, 15, 14, 13, 12, 11, 10
                };
                    // 3 - the least significant byte in Guid ByteArray [for SQL Server ORDER BY clause]
                    // 10 - the most significant byte in Guid ByteArray [for SQL Server ORDERY BY clause]
                }
                return sqlOrderMap;
            }
        }
    }
}
