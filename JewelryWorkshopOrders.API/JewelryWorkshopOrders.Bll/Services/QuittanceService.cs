using HandlebarsDotNet;
using JewelryWorkshopOrders.Bll.Interfaces;
using JewelryWorkshopOrders.Common.QuittanceDate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

namespace JewelryWorkshopOrders.Bll.Services
{
    public class QuittanceService : IQuittanceService
    {
        private readonly string _htmlTemplate = @"<html>
    <head>
        <style>
            h4{
                text-align: center;
            }

            .date{
                float: right;
            }

            table{
                width: 100%;
                background: black;
            }

            th,td{
                background: white;
            }

            hr{
                border-top: dashed;
            }

            body { 
                font-family: 'Arial';
            }
        </style>
    </head>
    <body>
        <h4>QUITTANCE</h4>
        <div>
            <div class='date'>
                <p><strong>Date of receipt:</strong> {{date}}</p> 
            </div>
            <div>
                <p><strong>Full name of the customer:</strong><br>{{surname}} {{name}} {{patronymic}}<br>
                <strong>Phone number:</strong>  {{phone}}</p> 
            </div>
        </div>
        <div>
            <p><strong>Metal:</strong>  {{MaterialType}}   <strong>Content:</strong> {{MaterialContent}}<br>
            <strong>Weight:</strong>  {{weight}}<br>
            <strong>Master:</strong>  {{master}}</p>
        </div>
        <table>
            <tr>
                <th>Order name</th>
                <th>Material</th>
                <th>Price</th>
            </tr>
            <tr>
                <td>{{productType}} {{product}}</td>
                <td>{{MaterialType}} {{MaterialContent}}</td>
                <td>{{price}}</td>
            </tr>
        </table>
        <p><strong>Customer's signature</strong> _________</p>
        <p><strong>Master's signature</strong> _________</p>
        <br>
        <hr>
        <h4>QUITTANCE</h4>
        <div>
            <div class='date'>
                <p><strong>Date of receipt:</strong> {{date}}</p> 
            </div>
            <div>
                <p><strong>Full name of the customer:</strong><br>{{surname}} {{name}} {{patronymic}}<br>
                <strong>Phone number:</strong>  {{phone}}</p> 
            </div>
        </div>
        <div>
            <p><strong>Metal:</strong>  {{MaterialType}}   <strong>Content:</strong> {{MaterialContent}}<br>
            <strong>Weight:</strong>  {{weight}}<br>
            <strong>Master:</strong>  {{master}}</p>
        </div>
        <table>
            <tr>
                <th>Order name</th>
                <th>Material</th>
                <th>Price</th>
            </tr>
            <tr>
                <td>{{productType}} {{product}}</td>
                <td>{{MaterialType}} {{MaterialContent}}</td>
                <td>{{price}}</td>
            </tr>
        </table>
        <p><strong>Customer's signature</strong> _________</p>
        <p><strong>Master's signature</strong> _________</p>
    </body>
</html>";

        public async Task<Stream> GetOrderQuittanceStream(OrderQuittance order)
        {
            var template = Handlebars.Compile(_htmlTemplate);
            var html = template(order);

            var pdf = await GeneratePdfAsync(html);
            //File.WriteAllBytes("hello.pdf", pdf);
            Stream stream = new MemoryStream(pdf);
            return stream;
        }


        private Task<byte[]> GeneratePdfAsync(string html)
        {
            var wkhtmltopdfPath = Path.Combine(Environment.CurrentDirectory, "Infrastructure/Rotativa");
            var result = WkhtmlDriver.Convert(wkhtmltopdfPath, new ConvertOptions().GetConvertOptions(), html);
            return Task.FromResult(result);
        }
    }
}
