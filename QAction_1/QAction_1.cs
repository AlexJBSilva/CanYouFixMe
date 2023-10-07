namespace Skyline.Protocol
{
    using System;
    using Skyline.DataMiner.Scripting;

    namespace SimpleTableExtension
    {
        public static class SimpleTableCommon
        {
            public static void AddRow(SLProtocol protocol)
            {
                int rowsCount = protocol.RowCount(Parameter.Simpletable.tablePid);
                string key = (rowsCount + 1).ToString();

                SimpletableQActionRow row = new SimpletableQActionRow
                {
                    Simpletableid_1001 = key,
                    Simpletableadddate_1002 = DateTime.UtcNow.ToOADate(),
                    Simpletableupdatedate_1003 = -1, // Not updated yet.
                };

                protocol.AddRow(Parameter.Simpletable.tablePid, row);
                RefreshInfo(protocol);
            }

            public static void UpdateRow(SLProtocol protocol, string key)
            {
                SimpletableQActionRow row = new SimpletableQActionRow
                {
                    Simpletableid_1001 = key,
                    Simpletableupdatedate_1003 = DateTime.UtcNow.ToOADate(),
                };

                protocol.SetRow(Parameter.Simpletable.tablePid, key, row);
            }

            public static void RefreshInfo(SLProtocol protocol)
            {
                string[] tableKeys = protocol.GetKeys(Parameter.Simpletable.tablePid);

                int[] ids = new int[] { Parameter.updaterow_discreetlist_35, Parameter.rowcount_1050 };
                object[] values = new object[] { string.Join(",", tableKeys), tableKeys.Length };
                protocol.SetParameters(ids, values);
            }
        }
    }
}