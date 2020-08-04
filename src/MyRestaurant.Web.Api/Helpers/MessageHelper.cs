using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Http;
using MyRestaurant.Model.Entities;
using MyRestaurant.Model.Models;
using MyRestaurant.Models.Constants;

namespace MyRestaurant.Web.Api.Helpers
{
    public static class MessageHelper<T> where T : class
    {
        public static ResponseModel<T> GetResponse(ResponseModel<T> response)
        {
            //XDocument doc = XDocument.Load(HttpContext.Server.MapPath("~/App_data/Messages.xml"));
            //if (doc != null)
            //{
            //    var modules = new Modules();
            //    modules = Deserialize<Modules>(doc.ToString());

            //    var error = modules.Error.Message.FirstOrDefault(m => m.Code.Trim() == response.ErrorCode);
            //    var success = modules.Success.Message.FirstOrDefault(m => m.Code.Trim() == response.SuccessCode);
            //    if (error != null)
            //    {
            //        response.ErrorMessage = error.message;
            //    }
            //    if (success != null)
            //    {
            //        response.SuccessMessage = success.message;
            //    }
            //}
            //return response;

            return null;
        }
        public static T1 Deserialize<T1>(string input) where T1 : class
        {
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(T1));

            using (StringReader sr = new StringReader(input))
            {
                return (T1)ser.Deserialize(sr);
            }
        }

        public static string Serialize<T1>(T1 ObjectToSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(ObjectToSerialize.GetType());
            string text = string.Empty;
            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, ObjectToSerialize);
                text = textWriter.ToString();
            }
            return text;
        }

        public static ResponseModel<PageResultModel<Message>> GetMessages(PageConfiguration configuration)
        {
            //XDocument doc = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_data/Messages.xml"));
            //ResponseModel<PageResultModel<Message>> response = new ResponseModel<PageResultModel<Message>>();
            //PageResultModel<Message> list = new PageResultModel<Message>();
            //if (doc != null)
            //{
            //    var modules = new Modules();
            //    modules = Deserialize<Modules>(doc.ToString());

            //    var successMessages = modules.Success.Message;
            //    var errorMessage = modules.Error.Message;
            //    foreach (var message in errorMessage)
            //    {
            //        message.Type = "Error";
            //    }
            //    foreach (var message in successMessages)
            //    {
            //        message.Type = "Success";
            //    }
            //    var query = errorMessage.Concat(successMessages).AsEnumerable();
            //    if (!string.IsNullOrEmpty(configuration.Search))
            //    {
            //        query = query
            //            .Where(m => m.Code.ToLower() == configuration.Search.ToLower()
            //            || m.message.ToLower().Contains(configuration.Search.ToLower())
            //            || m.Info.ToLower().Contains(configuration.Search.ToLower())
            //            );
            //    }
            //    var messages = query
            //        .OrderBy(m => m.Code)
            //        .Skip((configuration.PageNumber - 1) * configuration.PageSize).Take(configuration.PageSize);


            //    list.PageNumber = configuration.PageNumber;
            //    list.TotalPages = (int)Math.Ceiling((double)query.Count() / configuration.PageSize);
            //    list.Showing = messages.Count();


            //    list.Records = messages.ToList();
            //    list.TotalRecords = query.Count();
            //    response.IsSuccess = true;
            //    response.ResponseObject = list;
            //}


            return null;
        }


        public static ResponseModel<Message> SaveMessage(Message message)
        {
            ResponseModel<Message> response = new ResponseModel<Message>();
            try
            {
                //XDocument doc = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_data/Messages.xml"));
                //var node = doc.Element("Modules")
                //    .Element("Success");

                //if (string.IsNullOrEmpty(message.Id))
                //{
                //    var listElement = Deserialize<Modules>(doc.ToString());
                //    XElement Message = new XElement("Message");
                //    XElement infoElement = new XElement("info", message.Info);
                //    XElement messageElement = new XElement("message", message.message);
                //    string maxCode;
                //    string maxId;
                //    List<long> ids = new List<long>();
                //    List<long> codes = new List<long>();
                //    foreach (var element in listElement.Success.Message.Concat(listElement.Error.Message))
                //    {
                //        ids.Add(long.Parse(element.Id.Trim()));
                //    }

                //    if (message.Type == "Success")
                //    {
                //        foreach (var element in listElement.Success.Message)
                //        {
                //            codes.Add(long.Parse(element.Code.Trim()));
                //        }
                //        node = doc.Element("Modules").Element("Success");
                //    }
                //    else
                //    {
                //        foreach (var element in listElement.Error.Message)
                //        {
                //            if (element.Code.Trim() != CommonConstants.ErrorCode.InternalServerError)
                //                codes.Add(long.Parse(element.Code.Trim()));
                //        }
                //        node = doc.Element("Modules").Element("Error");
                //    }
                //    maxCode = (codes.Max() + 1).ToString();
                //    maxId = (ids.Max() + 1).ToString();
                //    XElement codeElement = new XElement("code", maxCode.ToString());
                //    XElement idElement = new XElement("Id", maxId);
                //    Message.Add(idElement);
                //    Message.Add(codeElement);
                //    Message.Add(infoElement);
                //    Message.Add(messageElement);
                //    node.Add(Message);
                //    response.SuccessCode = CommonConstants.SuccessCode.MessageSaved;
                //}
                //else
                //{
                //    if (message.Type == "Success")
                //    {
                //        node = doc.Element("Modules")
                //        .Element("Success")
                //        .Elements("Message")
                //        .FirstOrDefault(m => m.Element("Id").Value.Trim() == message.Id.ToString());
                //    }
                //    else
                //    {
                //        node = doc.Element("Modules")
                //            .Element("Error")
                //            .Elements("Message")
                //            .FirstOrDefault(m => m.Element("Id").Value.Trim() == message.Id.ToString());
                //    }

                //    node.Element("info").Value = message.Info;
                //    node.Element("message").Value = message.message;

                //    response.SuccessCode = CommonConstants.SuccessCode.MessageUpdated;
                //}
                //doc.Save(HttpContext.Current.Server.MapPath("~/App_data/Messages.xml"));
                //response.IsSuccess = true;

            }
            catch (Exception ex)
            {
                response.IsFailed = true;
                response.ErrorCode = CommonConstants.ErrorCode.InternalServerError;

            }
            return response;
        }
        public static ResponseModel<Message> GetMessage(string Id)
        {
            //XDocument doc = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_data/Messages.xml"));
            //ResponseModel<Message> response = new ResponseModel<Message>();
            //try
            //{
            //    if (doc != null)
            //    {

            //        var modules = new Modules();
            //        modules = Deserialize<Modules>(doc.ToString());
            //        var messageDetail = modules.Error.Message.FirstOrDefault(m => m.Id.Trim() == Id.Trim());
            //        if (messageDetail != null)
            //        {
            //            messageDetail.Type = "Error";
            //        }
            //        else
            //        {
            //            messageDetail = modules.Success.Message.FirstOrDefault(m => m.Id.Trim() == Id.Trim());
            //            if (messageDetail != null)
            //            {
            //                messageDetail.Type = "Success";
            //            }
            //        }
            //        response.IsSuccess = true;
            //        response.ResponseObject = messageDetail;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    response.IsFailed = true;
            //    response.ErrorCode = CommonConstants.ErrorCode.InternalServerError;
            //}
            //return response;
            return null;
        }
    }
}
