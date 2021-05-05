using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZaropaMVC.Models
{

    public interface IStudent
    {
        [Key]
        int id { get; set; }
        string position { get; set; }
        string name { get; set; }
        string imgurl { get; set; }
        string description { get; set; }
        List<IStudent> Employee { get; set; }
    }

    public class Student : IStudent
    {
        [Key]
        public int id { get; set; }
        public string position { get; set; }
        public string name { get; set; }
        public string imgurl { get; set; }
        public string description { get; set; }
        public List<IStudent> Employee { get; set; }
    }

    public class Admin : IStudent
    {
        [Key]
        public int id { get; set; }
        public string position { get; set; }
        public string name { get; set; }
        public string imgurl { get; set; }
        public string description { get; set; }
        public List<IStudent> Employee { get; set; }
    }

    public class PositionTier
    {
        public int tierid { get; set; }
        public Dictionary<string, List<Admin>> Employee { get; set; }
    }

    public class StudentModels
    {
        public int Id { get; set; }

        public List<string> TierList()
        {
            List<string> tiers = new List<string>
            {
                "tier_1",
                "tier_2",
                "tier_3"
            };
            return tiers;
        }


        public List<Admin> GetTier(string tiername)
        {
            Dictionary<string, List<Admin>> studentdictionary = new Dictionary<string, List<Admin>>();

            studentdictionary.Add("tier_1",
                new List<Admin>
            {

                new Admin(){
                    id =1,
                    imgurl ="~/Content/StudentPictures/student_lizade.png",
                    name ="Lizade Rodriguez",
                    position ="Chief Executive Officer",
                    description ="Admininstration" ,
                 Employee = null
                },

            });

            studentdictionary.Add("tier_2",
               new List<Admin>
           {

               new Admin(){
                    id =1,
                    imgurl ="~/Content/StudentPictures/student_arietty.png",
                    name ="Arietty Ortiz",
                    position ="Chief Operating Officer",
                    description ="Admininstration" ,
                 Employee = null
                },

           });

            studentdictionary.Add("tier_3",
            new List<Admin>
        {

              new Admin()
            {
                id = 1,
                imgurl = "~/Content/StudentPictures/student_ty.png",
                name = "Ty Allen",
                position = "VP of Human Resources",
                description = "Human Resources",
                Employee = new List<IStudent>
                                                                            {

                                                                              new Student(){
                                                                                   id =1,
                                                                                imgurl ="~/Content/StudentPictures/student_shelby.png",
                                                                                name ="Shelby Suarez",
                                                                                position ="Employee of HR",
                                                                                description ="Human Resources" ,

                                                                            },
                                                                               new Student(){
                                                                                   id =2,
                                                                                imgurl ="~/Content/StudentPictures/student_harpreet.png",
                                                                                name ="Harpreet Kaur",
                                                                                position ="Employee of HR",
                                                                                description ="Human Resources" ,

                                                                            }

                                                                            }
            },

                      new Admin(){
                    id =3,
                    imgurl ="~/Content/StudentPictures/student_chris.png",
                    name ="Christopher Lopez",
                    position ="Chief Finance Officer",
                    description ="Finance" ,
                 Employee = new List<IStudent>
                                                                         {
                                                                                             new Student(){
                                                                                               id =1,
                                                                                            imgurl ="~/Content/StudentPictures/student_emily.png",
                                                                                            name ="Emily Brandt",
                                                                                            position ="Employee of Finance",
                                                                                            description ="Finance" ,

                                                                                        }
                                                                         }
                },
                      new Admin(){
                    id =4,
                    imgurl ="~/Content/StudentPictures/student_john.png",
                    name ="John Brandt",
                    position ="Chief Information Officer",
                    description ="Design/IT" ,
                 Employee = new List<IStudent>
                                                                                     {
                                                                                                          new Student(){
                                                                                                           id =5,
                                                                                                        imgurl ="~/Content/StudentPictures/student_saimun.png",
                                                                                                        name ="Saimun Islam",
                                                                                                        position ="Employee of IT",
                                                                                                        description ="Design/IT" ,

                                                                                                    }
                                                                                     }
                },

                      new Admin(){
                    id =2,
                    imgurl ="~/Content/StudentPictures/student_danish.png",
                    name ="Danish Shaikh",
                    position ="Chief Marketing Officer",
                    description ="Marketing" ,
                 Employee = new List<IStudent>
                                                                         {
                                                                                          new Student(){
                                                                                           id =1,
                                                                                        imgurl ="~/Content/StudentPictures/student_Lindsay.png",
                                                                                        name ="Lindsay Adomaitis",
                                                                                        position ="Employee of Marketing",
                                                                                        description ="Marketing" ,

                                                                                    },
                                                                                          new Student(){
                                                                                           id =2,
                                                                                        imgurl ="~/Content/StudentPictures/student_sean.png",
                                                                                        name ="Sean Kilcarr",
                                                                                        position ="Employee of Marketing",
                                                                                        description ="Marketing" ,

                                                                                    }
                                                                         }
                },

        });







            return studentdictionary[tiername];
        }


    }
}