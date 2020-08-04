using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations;
using MyRestaurant.Data;
using MyRestaurant.Model.Entities;

namespace MyRestaurant.Web.Api.Migrations
{
    public class CuisineSeed
    {
        public static void Insert(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Cuisines",
                new string[] {
                "Name",
                "Description",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
                },
                new object[] {
                 "American",
                "",
                DateTime.Now,
                DateTime.Now,
                "1F109894-9942-4D28-89CD-3BD7B9993F4D",
                "1F109894-9942-4D28-89CD-3BD7B9993F4D",
                false
                });

            migrationBuilder.InsertData("Cuisines",
              new string[] {
                "Name",
                "Description",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
              },
              new object[] {
                "Andhra",
                "",
                DateTime.Now,
                DateTime.Now,
                "1F109894-9942-4D28-89CD-3BD7B9993F4D",
                "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false
              });


            migrationBuilder.InsertData("Cuisines",
              new string[] {
                "Name",
                "Description",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
              },
              new object[] {
                "Arabic",
                "",
                DateTime.Now,
                DateTime.Now,
                "1F109894-9942-4D28-89CD-3BD7B9993F4D",
                "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false
              });

            migrationBuilder.InsertData("Cuisines",
              new string[] {
                "Name",
                "Description",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
              },
              new object[] {
                "Bengali",
                "",
                DateTime.Now,
                DateTime.Now,
                "1F109894-9942-4D28-89CD-3BD7B9993F4D",
                "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false
              });

            migrationBuilder.InsertData("Cuisines",
              new string[] {
                "Name",
                "Description",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
              },
              new object[] {
                "Biryani",
                "",
                DateTime.Now,
                DateTime.Now,
                "1F109894-9942-4D28-89CD-3BD7B9993F4D",
                "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false
              });

            migrationBuilder.InsertData("Cuisines",
              new string[] {
                "Name",
                "Description",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
              },
              new object[] {
                "Burgers",
                "",
                DateTime.Now,
                DateTime.Now,
                "1F109894-9942-4D28-89CD-3BD7B9993F4D",
                "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false
              });


            migrationBuilder.InsertData("Cuisines",
               new string[] {
                "Name",
                "Description",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
               },
               new object[] {
                "Cakes-Bakery",
                "",
                DateTime.Now,
                DateTime.Now,
                "1F109894-9942-4D28-89CD-3BD7B9993F4D",
                "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false
               });

            migrationBuilder.InsertData("Cuisines",
               new string[] {
                "Name",
                "Description",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
               },
               new object[] {
                "Chinese",
                "",
                DateTime.Now,
                DateTime.Now,
                "1F109894-9942-4D28-89CD-3BD7B9993F4D",
                "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false
               });
            migrationBuilder.InsertData("Cuisines",
               new string[] {
                "Name",
                "Description",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
               },
               new object[] {
                "Continental",
                "",
                DateTime.Now,
                DateTime.Now,
                "1F109894-9942-4D28-89CD-3BD7B9993F4D",
                "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false
               });

            migrationBuilder.InsertData("Cuisines",
               new string[] {
                "Name",
                "Description",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
               },
               new object[] {
           "Desserts",
           "",
           DateTime.Now,
           DateTime.Now,
           "1F109894-9942-4D28-89CD-3BD7B9993F4D",
           "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false
               });


            migrationBuilder.InsertData("Cuisines",
               new string[] {
                "Name",
                "Description",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
               },
               new object[] {
                "European",
                "",
                DateTime.Now,
                DateTime.Now,
                "1F109894-9942-4D28-89CD-3BD7B9993F4D",
                "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false
               });
            migrationBuilder.InsertData("Cuisines",
          new string[] {
                "Name",
                "Description",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
          },
          new object[] {
                "Fast Food",
                "",
                DateTime.Now,
                DateTime.Now,
                "1F109894-9942-4D28-89CD-3BD7B9993F4D",
                "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false
          });

            migrationBuilder.InsertData("Cuisines",
          new string[] {
                "Name",
                "Description",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
          },
          new object[] {
                "Hyderabadi",
                "",
                DateTime.Now,
                DateTime.Now,
                "1F109894-9942-4D28-89CD-3BD7B9993F4D",
                "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false
          });


            migrationBuilder.InsertData("Cuisines",
          new string[] {
                "Name",
                "Description",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
          },
          new object[] {
                "Ice creams",
                "",
                DateTime.Now,
                DateTime.Now,
                "1F109894-9942-4D28-89CD-3BD7B9993F4D",
                "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false
          });

            migrationBuilder.InsertData("Cuisines",
               new string[] {
                "Name",
                "Description",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
               },
               new object[] {
                "Japanese",
                "",
                DateTime.Now,
                DateTime.Now,
                "1F109894-9942-4D28-89CD-3BD7B9993F4D",
                "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false

               });
            migrationBuilder.InsertData("Cuisines",
          new string[] {
                "Name",
                "Description",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
          },
          new object[] {
                 "Juices",
                 "",
                 DateTime.Now,
                 DateTime.Now,
                 "1F109894-9942-4D28-89CD-3BD7B9993F4D",
                 "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false

          });
            migrationBuilder.InsertData("Cuisines",
         new string[] {
                "Name",
                "Description",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
         },
         new object[] {
               "Kebab",
               "",
               DateTime.Now,
               DateTime.Now,
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false
         });

            migrationBuilder.InsertData("Cuisines",
                new string[] {
                "Name",
                "Description",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
                },
                new object[] {
               "Lebanese",
               "",
               DateTime.Now,
               DateTime.Now,
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false
                });

            migrationBuilder.InsertData("Cuisines",
               new string[] {
                "Name",
                "Description",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
               },
               new object[] {

               "Maharashtrian",
               "",
               DateTime.Now,
               DateTime.Now,
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false
               });
            migrationBuilder.InsertData("Cuisines",
              new string[] {
                "Name",
                "Description",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
              },
              new object[] {
               "Mexican",
               "",
               DateTime.Now,
               DateTime.Now,
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false
              });
            migrationBuilder.InsertData("Cuisines",
              new string[] {
                "Name",
                "Description",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
              },
              new object[] {
               "Middle Eastern",
               "",
               DateTime.Now,
               DateTime.Now,
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false
              });
            migrationBuilder.InsertData("Cuisines",
               new string[] {
                "Name",
                "Description",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
               },
               new object[] {
               "Mughlai",
               "",
               DateTime.Now,
               DateTime.Now,
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false
               });
            migrationBuilder.InsertData("Cuisines",
                      new string[] {
                "Name",
                "Description",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
                      },
                      new object[] {
               "North Indian",
               "",
               DateTime.Now,
               DateTime.Now,
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false
                      });
            migrationBuilder.InsertData("Cuisines",
               new string[] {
                "Name",
                "Description",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
               },
               new object[] {
               "Pan-Asian",
               "",
               DateTime.Now,
               DateTime.Now,
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false
               });
            migrationBuilder.InsertData("Cuisines",
               new string[] {
                "Name",
                "Description",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
               },
               new object[] {
               "Pizza",
               "",
               DateTime.Now,
               DateTime.Now,
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false
               });
            migrationBuilder.InsertData("Cuisines",
               new string[] {
                "Name",
                "Description",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
               },
               new object[] {
               "Punjabi",
               "",
               DateTime.Now,
               DateTime.Now,
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false
               });
            migrationBuilder.InsertData("Cuisines",
               new string[] {
                "Name",
                "Description",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
               },
               new object[] {
               "Rajasthani",
               "",
               DateTime.Now,
               DateTime.Now,
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false
               });
            migrationBuilder.InsertData("Cuisines",
           new string[] {
                "Name",
                "Description",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
           },
           new object[] {
               "Regional",
               "",
               DateTime.Now,
               DateTime.Now,
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false
           });
            migrationBuilder.InsertData("Cuisines",
              new string[] {
                "Name",
                "Description",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
              },
              new object[] {
               "Italian",
               "",
               DateTime.Now,
               DateTime.Now,
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false
              });
            migrationBuilder.InsertData("Cuisines",
               new string[] {
                "Name",
                "Description",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
               },
               new object[] {
               "Salads",
               "",
               DateTime.Now,
               DateTime.Now,
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               "1F109894-9942-4D28-89CD-3BD7B9993F4D" ,
               false});

            migrationBuilder.InsertData("Cuisines",
               new string[] {
                "Name",
                "Description",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
               },
               new object[] {
               "Sandwiches",
               "",
               DateTime.Now,
               DateTime.Now,
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false
               });
            migrationBuilder.InsertData("Cuisines",
               new string[] {
                "Name",
                "Description",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
               },
               new object[] {
               "Seafood",
               "",
               DateTime.Now,
               DateTime.Now,
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false
               });

            migrationBuilder.InsertData("Cuisines",
           new string[] {
                "Name",
                "Description",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
           },
           new object[] {

               "Shakes and Smoothies",
               "",
               DateTime.Now,
               DateTime.Now,
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false
          });
            migrationBuilder.InsertData("Cuisines",
               new string[] {
                "Name",
                "Description",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
               },
               new object[] {
               "Snacks",
               "",
               DateTime.Now,
               DateTime.Now,
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false
               });
            migrationBuilder.InsertData("Cuisines",
               new string[] {
                "Name",
                "Description",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
               },
               new object[] {
               "South Indian",
               "",
               DateTime.Now,
               DateTime.Now,
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false
               });
            migrationBuilder.InsertData("Cuisines",
               new string[] {
                "Name",
                "Description",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
               },
               new object[] {
               "Tea - Coffee",
               "",
               DateTime.Now,
               DateTime.Now,
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false
               });

            migrationBuilder.InsertData("Cuisines",
              new string[] {
                "Name",
                "Description",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
              },
              new object[] {
               "Thai",
               "",
               DateTime.Now,
               DateTime.Now,
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false
              });
            migrationBuilder.InsertData("Cuisines",
               new string[] {
                "Name",
                "Description",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
               },
               new object[] {
               "Tibetan",
               "",
               DateTime.Now,
               DateTime.Now,
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false
               });
            migrationBuilder.InsertData("Cuisines",
              new string[] {
                "Name",
                "Description",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
              },
              new object[] {
               "Vegetarian",
               "",
               DateTime.Now,
               DateTime.Now,
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false
              });
            migrationBuilder.InsertData("Cuisines",
              new string[] {
                "Name",
                "Description",
                "CreatedDate",
                "UpdatedDate",
                "CreatedById",
                "UpdatedById",
                "IsDeleted"
              },
              new object[] {
               "Wraps",
               "",
               DateTime.Now,
               DateTime.Now,
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               "1F109894-9942-4D28-89CD-3BD7B9993F4D",
               false
              });
        }
    }
}
