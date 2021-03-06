using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using janrain.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace janrain.Controllers
{
    public class DataController : Controller
    {
        public Dictionary<string, string> AoiDic = new Dictionary<string, string>();
        public Dictionary<string, string> SpecialtyDic = new Dictionary<string, string>();


        [HttpGet]
        public async Task<IActionResult> Transform()
        {

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


            var filePath = $"{Directory.GetCurrentDirectory()}\\origin";
            var outputPath = $"{Directory.GetCurrentDirectory()}\\transformed";
            var ff = Directory.GetFiles(filePath);
            foreach (var f in ff)
            {
                var newstring = new List<string>();
                newstring.Add("givenName|familyName|email|customerType|customTypeCN|jobTitle|jobTitleCN|organizationName|organizationCode|addressLine1|province|district|city|uuid|customerId|validationStatus|brandedConsent|msdCorporateInfoStatus|msdClinicalInfoStatus|msdProductInfoStatus|mainSpecialty|aoi1|aoi2|aoi3|specialty1|specialty2|specialty3|specialty4|specialty5|specialty6|specialty7|specialty8|specialty9|aoi1cn|aoi2cn|aoi3cn|specialty1cn|specialty2cn|specialty3cn|specialty4cn|specialty5cn|specialty6cn|specialty7cn|specialty8cn|specialty9cn");
                FileStream fileStream = new FileStream(f, FileMode.Open);
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    string line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        if (!line.StartsWith("givenName"))
                        {
                            var oo = line.Split("|");
                            var last = oo[oo.Length - 1];
                            if (String.IsNullOrEmpty(last) || last == "[]")
                            {
                                //no aoi
                                var tempstring = String.Join("|", oo.SkipLast(1)) + "|null|null|null|null|null|null|null|null|null|null|null|null|null|null|null|null|null|null|null|null|null|null|null|null";
                                newstring.Add(tempstring);

                            }
                            else
                            {
                                //has aoi
                                var aoijson = JsonConvert.DeserializeObject(last) as JArray;
                                if (aoijson != null)
                                {
                                    string[] aois = new string[3] { "null", "null", "null" };
                                    string[] specialties = new string[9] { "null", "null", "null", "null", "null", "null", "null", "null", "null" };
                                    string[] aoiscn = new string[3] { "null", "null", "null" };
                                    string[] specialtiescn = new string[9] { "null", "null", "null", "null", "null", "null", "null", "null", "null" };

                                    for (int i = 0; i < aoijson.Count; i++)
                                    {
                                        aois[i] = aoijson[i]["aoi"].ToString();
                                        string aoicn;
                                        if (AoiDic.TryGetValue(aois[i], out aoicn))
                                            aoiscn[i] = aoicn;
                                        var spes = aoijson[i]["specialty"].ToString().Split(",");
                                        if (spes.Length > 0)
                                        {
                                            if (i == 0)
                                            {
                                                specialties[0] = spes[0];
                                                if (specialties[0] != "null")
                                                {
                                                    string spcn;
                                                    if (SpecialtyDic.TryGetValue(specialties[0], out spcn))
                                                        specialtiescn[0] = spcn;
                                                }

                                                specialties[1] = spes.Length > 1 ? spes[1] : "null";
                                                if (specialties[1] != "null")
                                                {
                                                    string spcn;
                                                    if (SpecialtyDic.TryGetValue(specialties[1], out spcn))
                                                        specialtiescn[1] = spcn;
                                                }

                                                specialties[2] = spes.Length > 2 ? spes[2] : "null";
                                                if (specialties[2] != "null")
                                                {
                                                    string spcn;
                                                    if (SpecialtyDic.TryGetValue(specialties[2], out spcn))
                                                        specialtiescn[2] = spcn;
                                                }
                                            }
                                            else if (i == 1)
                                            {
                                                specialties[3] = spes[0];
                                                if (specialties[3] != "null")
                                                {
                                                    string spcn;
                                                    if (SpecialtyDic.TryGetValue(specialties[3], out spcn))
                                                        specialtiescn[3] = spcn;
                                                }

                                                specialties[4] = spes.Length > 1 ? spes[1] : "null";
                                                if (specialties[4] != "null")
                                                {
                                                    string spcn;
                                                    if (SpecialtyDic.TryGetValue(specialties[4], out spcn))
                                                        specialtiescn[4] = spcn;
                                                }

                                                specialties[5] = spes.Length > 2 ? spes[2] : "null";
                                                if (specialties[5] != "null")
                                                {
                                                    string spcn;
                                                    if (SpecialtyDic.TryGetValue(specialties[5], out spcn))
                                                        specialtiescn[5] = spcn;
                                                }
                                            }
                                            else if (i == 2)
                                            {
                                                specialties[6] = spes[0];
                                                if (specialties[6] != "null")
                                                {
                                                    string spcn;
                                                    if (SpecialtyDic.TryGetValue(specialties[6], out spcn))
                                                        specialtiescn[6] = spcn;
                                                }

                                                specialties[7] = spes.Length > 1 ? spes[1] : "null";
                                                if (specialties[7] != "null")
                                                {
                                                    string spcn;
                                                    if (SpecialtyDic.TryGetValue(specialties[7], out spcn))
                                                        specialtiescn[7] = spcn;
                                                }
                                                
                                                specialties[8] = spes.Length > 2 ? spes[2] : "null";
                                                if (specialties[8] != "null")
                                                {
                                                    string spcn;
                                                    if (SpecialtyDic.TryGetValue(specialties[8], out spcn))
                                                        specialtiescn[8] = spcn;
                                                }
                                            }
                                        }

                                    }

                                    //do the mapping
                                    // for (int j = 0; j < aois.Length; j++)
                                    // {
                                    //     string aoicn;
                                    //     if (AoiDic.TryGetValue(aois[j], out aoicn))
                                    //     {
                                    //         aoiscn[j] = aoicn;
                                    //     }
                                    // }

                                    // for (int j = 0; j < specialties.Length; j++)
                                    // {
                                    //     string spcn;
                                    //     if (SpecialtyDic.TryGetValue(specialties[j], out spcn))
                                    //     {
                                    //         specialtiescn[j] = spcn;
                                    //     }
                                    // }

                                    var aoistring = $"|{aois[0]}|{aois[1]}|{aois[2]}|{specialties[0]}|{specialties[1]}|{specialties[2]}|{specialties[3]}|{specialties[4]}|{specialties[5]}|{specialties[6]}|{specialties[7]}|{specialties[8]}|{aoiscn[0]}|{aoiscn[1]}|{aoiscn[2]}|{specialtiescn[0]}|{specialtiescn[1]}|{specialtiescn[2]}|{specialtiescn[3]}|{specialtiescn[4]}|{specialtiescn[5]}|{specialtiescn[6]}|{specialtiescn[7]}|{specialtiescn[8]}";
                                    var tempstring = String.Join("|", oo.SkipLast(1)) + aoistring;
                                    newstring.Add(tempstring);
                                }
                                else
                                {
                                    var tempstring = String.Join("|", oo.SkipLast(1)) + "|null|null|null|null|null|null|null|null|null|null|null|null|null|null|null|null|null|null|null|null|null|null|null|null";
                                    newstring.Add(tempstring);

                                }


                            }
                        }

                    }


                }
                var oldfile = new FileInfo(f);
                var newfile = oldfile.Name.Split(".")[0] + "_out";
                FileInfo myFile = new FileInfo($"{outputPath}\\{newfile}.csv");
                StreamWriter sW = myFile.CreateText();
                foreach (var s in newstring.ToArray())
                {
                    sW.WriteLine(s);
                }
                sW.Close();
            }

            return Ok(new { count = ff.Count() });
        }

        public IActionResult test()
        {
            return Ok("aaa");

        }

    }
}
