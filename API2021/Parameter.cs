﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace API2021
{
    public class Wilayah
    {
        public string nama_wilayah { get; set; }
        public string tanggal { get; set; }
        public string id_wilayah { get; set; }


        public static DataSet GetWilayah()
        {
            string query = "SELECT b.tanggal, b.id_bangunan, w.nama_wilayah FROM as_bangunan b join as_wilayah w on b.id_wilayah=w.id_wilayah ";
            DataSet ds = Settings.LoadDataSet(query);
            return ds;
        }
    }

    public class Ruangan
    {
        public string nama_wilayah { get; set; }
        public string tanggal { get; set; }
        public string id_wilayah { get; set; }
    }
}
