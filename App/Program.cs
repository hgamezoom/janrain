using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace App
{
    class Program
    {
        static Dictionary<string, string> AoiDic = new Dictionary<string, string>();
        static Dictionary<string, string> SpecialtyDic = new Dictionary<string, string>();
        static Dictionary<string, string> customtypeDic = new Dictionary<string, string>();

        static Dictionary<string, string> jobtitleDic = new Dictionary<string, string>();
        static void Main(string[] args)
        {

            customtypeDic.Add("RP", "药剂师");
            customtypeDic.Add("GD", "全科医生");
            customtypeDic.Add("SE", "专科医生");
            customtypeDic.Add("EE", "默沙东员工");
            customtypeDic.Add("OT", "医保/招标人员");
            customtypeDic.Add("NR", "护士");
            customtypeDic.Add("DD", "牙医");
            customtypeDic.Add("DV", "兽医");
            customtypeDic.Add("JO", "出版商/记者");
            customtypeDic.Add("ME", "医学生");


            jobtitleDic.Add("CPHARMA", "主任药师");
            jobtitleDic.Add("VCPHARM", "副主任药师");
            jobtitleDic.Add("PHARMIC", "主管药师");
            jobtitleDic.Add("PHARMA", "药师");
            jobtitleDic.Add("ASPHARM", "药士");
            jobtitleDic.Add("CDOC", "主任医师");
            jobtitleDic.Add("VCDOC", "副主任医师");
            jobtitleDic.Add("DOCIC", "主治医师");
            jobtitleDic.Add("RESDOC", "住院医师");
            jobtitleDic.Add("ASSDOC", "医士");

            AoiDic.Add("INFEC", "抗感染领域");
            AoiDic.Add("CARDVASC", "心血管领域");
            AoiDic.Add("ENDO", "内分泌领域");
            AoiDic.Add("ANDR", "男性健康领域");
            AoiDic.Add("PULMRESP", "呼吸领域");
            AoiDic.Add("MUSCSKEL", "骨骼及疼痛领域");
            AoiDic.Add("ONCO", "肿瘤领域");
            AoiDic.Add("OBGYN", "女性健康领域");
            AoiDic.Add("PSY", "神经精神领域");
            AoiDic.Add("DERM", "皮肤科领域");
            AoiDic.Add("FM", "全科领域");
            AoiDic.Add("SURG", "外科领域");
            AoiDic.Add("OTMTA", "其他领域");
            AoiDic.Add("ANTHS", "麻醉领域");
            AoiDic.Add("VACCN", "疫苗领域");

            SpecialtyDic.Add("ID", "感染科");
            SpecialtyDic.Add("UCM", "烧伤科");
            SpecialtyDic.Add("MM", "微生物学");
            SpecialtyDic.Add("CL", "检验科/化验科");
            SpecialtyDic.Add("CCM", "ICU");
            SpecialtyDic.Add("HEM", "血液科");
            SpecialtyDic.Add("HEP", "传染科/肝病科");
            SpecialtyDic.Add("B", "细菌室");
            SpecialtyDic.Add("C", "心内科");
            SpecialtyDic.Add("CD", "高血压科");
            SpecialtyDic.Add("DIA", "糖尿病科");
            SpecialtyDic.Add("END", "内分泌科");
            SpecialtyDic.Add("OPHTHAL", "眼科");
            SpecialtyDic.Add("REN", "生殖科/IVF");
            SpecialtyDic.Add("AD", "男科学");
            SpecialtyDic.Add("GM", "生殖泌尿科");
            SpecialtyDic.Add("URO", "泌尿科");
            SpecialtyDic.Add("OTO", "耳鼻咽喉科");
            SpecialtyDic.Add("PDP", "儿科/呼吸科");
            SpecialtyDic.Add("PLMN", "呼吸科");
            SpecialtyDic.Add("PD", "儿科");
            SpecialtyDic.Add("MPD", "儿科/儿内科");
            SpecialtyDic.Add("IG", "免疫科");
            SpecialtyDic.Add("O", "骨科");
            SpecialtyDic.Add("T", "创伤科");
            SpecialtyDic.Add("CWMO", "骨科/中医骨伤科");
            SpecialtyDic.Add("PMGM", "疼痛科");
            SpecialtyDic.Add("RHU", "风湿科");
            SpecialtyDic.Add("IMG", "老年科");
            SpecialtyDic.Add("EOM", "骨质疏松科");
            SpecialtyDic.Add("PM", "康复科");
            SpecialtyDic.Add("ONG", "肿瘤科");
            SpecialtyDic.Add("RO", "放化疗科");
            SpecialtyDic.Add("R", "放射科");
            SpecialtyDic.Add("OGS", "外科/乳腺科");
            SpecialtyDic.Add("OBG", "妇产科");
            SpecialtyDic.Add("MFM", "妇婴保健");
            SpecialtyDic.Add("FPL", "生殖科/计划生育科（人流手术室）");
            SpecialtyDic.Add("GYN", "妇科");
            SpecialtyDic.Add("PSY", "心理科");
            SpecialtyDic.Add("P", "精神科");
            SpecialtyDic.Add("N", "神经内科");
            SpecialtyDic.Add("D", "皮肤科");
            SpecialtyDic.Add("CWM", "中西结合科");
            SpecialtyDic.Add("IFP", "普内科");
            SpecialtyDic.Add("GP", "全科");
            SpecialtyDic.Add("AHF", "外科/血管-移植外科");
            SpecialtyDic.Add("CTS", "外科/心胸外科");
            SpecialtyDic.Add("GS", "外科/普外科");
            SpecialtyDic.Add("PLR", "整形科");
            SpecialtyDic.Add("TTS", "移植科");
            SpecialtyDic.Add("IDR", "胸肺科");
            SpecialtyDic.Add("NS", "外科/神经外科（脑外科）");
            SpecialtyDic.Add("PDS", "儿科/儿外科");
            SpecialtyDic.Add("MMAP", "行政科室/院长办公室");
            SpecialtyDic.Add("PH", "保健科");
            SpecialtyDic.Add("MMA", "行政科室/医务科");
            SpecialtyDic.Add("A", "变态反应科");
            SpecialtyDic.Add("SCH", "院校医护科");
            SpecialtyDic.Add("PA", "药理学");
            SpecialtyDic.Add("NEP", "肾内科");
            SpecialtyDic.Add("NEPH", "肾内科/透析中心");
            SpecialtyDic.Add("ST", "口腔科");
            SpecialtyDic.Add("CSM", "高干科");
            SpecialtyDic.Add("MDM", "医药管理");
            SpecialtyDic.Add("GE", "消化科");
            SpecialtyDic.Add("NM", "核医学");
            SpecialtyDic.Add("ESM", "运动医学科");
            SpecialtyDic.Add("TCM", "中医科");
            SpecialtyDic.Add("PHA", "药店");
            SpecialtyDic.Add("OCT", "职业治疗科");
            SpecialtyDic.Add("PHM", "药剂科");
            SpecialtyDic.Add("EM", "急诊科");
            SpecialtyDic.Add("OS", "其他");
            SpecialtyDic.Add("PS", "外科/整形外科");
            SpecialtyDic.Add("AN", "麻醉科");
            SpecialtyDic.Add("IMV", "CDC/计免科");
            SpecialtyDic.Add("MB", "CDC/生物制剂科");
            SpecialtyDic.Add("EP", "CDC/流病科");
            SpecialtyDic.Add("PHP", "公共卫生科");
            SpecialtyDic.Add("IDPC", "传染病防制科");

            Console.WriteLine("type command : starttransform");
            //var cmd = Console.ReadLine();
            var cmd="starttransform";
            if (cmd == "starttransform")
            {

                Console.WriteLine("starting...");

                var filePath = $"{Directory.GetCurrentDirectory()}\\origin";
                var outputPath = $"{Directory.GetCurrentDirectory()}\\transformed";
                var ff = Directory.GetFiles(filePath);
                foreach (var f in ff)
                {
                    var newstring = new List<string>();
                    newstring.Add("givenName|familyName|email|customerType|customTypeCN|jobTitle|jobTitleCN|organizationName|organizationCode|addressLine1|province|district|city|uuid|customerId|validationStatus|brandedConsent|msdCorporateInfoStatus|msdClinicalInfoStatus|msdProductInfoStatus|mainSpecialty|aoi1|aoi2|aoi3|aoispecialty1|aoispecialty2|aoispecialty3|aoi1cn|aoi2cn|aoi3cn|aoispecialty1cn|aoispecialty2cn|aoispecialty3cn");
                    FileStream fileStream = new FileStream(f, FileMode.Open);
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (!line.StartsWith("givenName"))
                            {
                                var oo = line.Split("|").ToList();
                                var customtype=oo[3];
                                var jobTitle=oo[4];
                                 string customtypecn;
                                            if (customtypeDic.TryGetValue(customtype, out customtypecn))
                                                oo.Insert(4,customtypecn);
                                                else
                                                  oo.Insert(4,"null");

                                string jobtitlecn;
                                            if (jobtitleDic.TryGetValue(jobTitle, out jobtitlecn))
                                                oo.Insert(6,jobtitlecn);
                                          else
                                           oo.Insert(6,"null");

                                var last = oo.Last();
                                if (String.IsNullOrEmpty(last) || last == "[]")
                                {
                                    //no aoi
                                    var tempstring = String.Join("|", oo.SkipLast(1)) + "|null|null|null|null|null|null|null|null|null|null|null|null";
                                    newstring.Add(tempstring);

                                }
                                else
                                {
                                    //has aoi
                                    var aoijson = JsonConvert.DeserializeObject(last) as JArray;
                                    if (aoijson != null)
                                    {
                                        string[] aois = new string[3] { "null", "null", "null" };
                                        string[] specialties = new string[3] { "null", "null", "null"};
                                        string[] aoiscn = new string[3] { "null", "null", "null" };
                                        string[] specialtiescn = new string[3] { "null", "null", "null"};

                                        for (int i = 0; i < 3; i++)
                                        {
                                            aois[i] = aoijson[i]["aoi"].ToString();
                                            string aoicn;
                                            if (AoiDic.TryGetValue(aois[i], out aoicn))
                                                aoiscn[i] = aoicn;
                                         
                                            specialties[i]=aoijson[i]["specialty"].ToString();
                                            var cnlist=new List<string>();
                                            foreach(var sp in specialties[i].Split(","))
                                            {
                                                //find specialty cn
                                            
                                                  string spcn;
                                                        if (SpecialtyDic.TryGetValue(sp, out spcn))
                                                  cnlist.Add(spcn);

                                            }
                                            specialtiescn[i]=String.Join(",",cnlist);
                                           
                                        }


                                        var aoistring = $"|{aois[0]}|{aois[1]}|{aois[2]}|{specialties[0]}|{specialties[1]}|{specialties[2]}|{aoiscn[0]}|{aoiscn[1]}|{aoiscn[2]}|{specialtiescn[0]}|{specialtiescn[1]}|{specialtiescn[2]}";
                                        var tempstring = String.Join("|", oo.SkipLast(1)) + aoistring;
                                        newstring.Add(tempstring);
                                    }
                                    else
                                    {
                                        var tempstring = String.Join("|", oo.SkipLast(1)) + "|null|null|null|null|null|null|null|null|null|null|null|null";
                                        newstring.Add(tempstring);

                                    }


                                }
                            }

                        }


                    }
                    var oldfile = new FileInfo(f);
                    var newfile = oldfile.Name.Split(".")[0] + "_out"+DateTime.Now.Ticks.ToString();
                    FileInfo myFile = new FileInfo($"{outputPath}\\{newfile}.csv");
                    StreamWriter sW = myFile.CreateText();
                    foreach (var s in newstring.ToArray())
                    {
                        sW.WriteLine(s);
                    }
                    sW.Close();
                    Console.WriteLine($"{newfile} completed");
                }
            }


        }
    }
}
