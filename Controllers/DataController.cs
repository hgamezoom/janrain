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

        [HttpGet]
        public async Task<IActionResult> Transform()
        {
            // long size = files.Sum(f => f.Length);

            // // full path to file in temp location
            // var filePath = $"{Directory.GetCurrentDirectory()}\\{DateTime.Now.Ticks}.txt";

            // foreach (var formFile in files)
            // {
            //     if (formFile.Length > 0)
            //     {
            //         using (var stream = new FileStream(filePath, FileMode.Create))
            //         {
            //             await formFile.CopyToAsync(stream);
            //         }
            //     }
            // }

            // FileStream fileStream = new FileStream(filePath, FileMode.Open);
            // using (StreamReader reader = new StreamReader(fileStream))
            // {
            //     string line;
            //      while ((line = reader.ReadLine()) != null) 
            //     {
            //          var pp=line;
            //     }


            // }
            var filePath = $"{Directory.GetCurrentDirectory()}\\origin";
            var ff = Directory.GetFiles(filePath);
            foreach (var f in ff)
            {
                var newstring=new List<string>();
                newstring.Add("givenName|familyName|email|customerType|customTypeCN|jobTitle|jobTitleCN|organizationName|organizationCode|addressLine1|province|district|city|uuid|customerId|validationStatus|brandedConsent|msdCorporateInfoStatus|msdClinicalInfoStatus|msdProductInfoStatus|mainSpecialty|aoi1|aoi2|aoi3|specialty1|specialty2|specialty3|specialty4|specialty5|specialty6|specialty7|specialty8|specialty9");
                FileStream fileStream = new FileStream(f, FileMode.Open);
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    string line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        if(!line.StartsWith("givenName"))
                        {
                        var oo = line.Split("|");
                        var last=oo[oo.Length-1];
                        if(String.IsNullOrEmpty(last)||last=="[]")
                        {
                            //no aoi
                            var tempstring=String.Join("|",oo.SkipLast(1))+"|null|null|null|null|null|null|null|null|null|null|null|null";
                            newstring.Add(tempstring);

                        }
                        else
                        {
                            //has aoi
                            var aoijson=JsonConvert.DeserializeObject(last) as JArray;
                            if(aoijson!=null)
                            {
                                string[] aois=new string[3]{"null","null","null"};
                                string[] specialties=new string[9]{"null","null","null","null","null","null","null","null","null"};
                                for(int i=0;i<aoijson.Count;i++)
                                {
                                 aois[i]=aoijson[i]["aoi"].ToString();
                                 var spes=aoijson[i]["specialty"].ToString().Split(",");
                                 if(spes.Length>0)
                                 {
                                     if(i==0)
                                     {
                                         specialties[0]=spes[0];
                                          specialties[1]=spes.Length>1?spes[1]:"null";
                                           specialties[2]=spes.Length>2?spes[2]:"null";
                                     }
                                     else if(i==1)
                                     {
                                         specialties[3]=spes[0];
                                          specialties[4]=spes.Length>1?spes[1]:"null";
                                           specialties[5]=spes.Length>2?spes[2]:"null";
                                     }
                                     else if(i==2)
                                     {
                                         specialties[6]=spes[0];
                                          specialties[7]=spes.Length>1?spes[1]:"null";
                                           specialties[8]=spes.Length>2?spes[2]:"null";
                                     }
                                 }

                                }
                                var aoistring=$"|{aois[0]}|{aois[1]}|{aois[2]}|{specialties[0]}|{specialties[1]}|{specialties[2]}|{specialties[3]}|{specialties[4]}|{specialties[5]}|{specialties[6]}|{specialties[7]}|{specialties[8]}";
                                var tempstring=String.Join("|",oo.SkipLast(1))+aoistring;
                                newstring.Add(tempstring);
                            }
                            else
                            {
                            var tempstring=String.Join("|",oo.SkipLast(1))+"|null|null|null|null|null|null|null|null|null|null|null|null";
                            newstring.Add(tempstring);

                            }


                        }
                        }

                    }


                }


                // FileInfo myFile = new FileInfo(@"C:\temp\a.txt");
                // StreamWriter sW = myFile.CreateText();
                // string[] strs = { "早上好", "下午好", "晚上好" };
                // foreach (var s in strs)
                // {
                //     sW.WriteLine(s);
                // }
                // sW.Close();
            }

            return Ok(new { count = ff.Count() });
        }

        public IActionResult test()
        {
            return Ok("aaa");

        }

    }
}
