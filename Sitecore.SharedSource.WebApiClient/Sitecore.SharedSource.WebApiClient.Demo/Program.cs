using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using Sitecore.SharedSource.WebApiClient.Data;
using Sitecore.SharedSource.WebApiClient.Entities;
using Sitecore.SharedSource.WebApiClient.Interfaces;
using Sitecore.SharedSource.WebApiClient.Net;
using Sitecore.SharedSource.WebApiClient.Security;

namespace Sitecore.SharedSource.WebApiClient.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            const string host = "http://yourhost/";

            var context = new SitecoreDataContext(host);

            // expression query example

            ExpressionQuerySample(context);

            // single item query example

            ItemQuerySample(context);

            // working with fields example
            
            FieldsSample(context);

            // secure context

            var secureContext = new AuthenticatedSitecoreDataContext(
                                            host,
                                            new SitecoreCredentials
                                                                {
                                                                    UserName = "extranet\\",
                                                                    Password = ""
                                                                });

            // credentials

            CredentialsSample(secureContext);

            // encrypted credentials
           
            var encryptedSecureContext = new AuthenticatedSitecoreDataContext(
                host,
                new SitecoreCredentials
                    {
                        UserName = "extranet\\",
                        Password = "",
                        EncryptHeaders = true
                    });

            EncryptedCredentialsSample(encryptedSecureContext);
        }

        private static void EncryptedCredentialsSample(AuthenticatedSitecoreDataContext context)
        {
            var query = new SitecoreItemQuery(SitecoreQueryType.Read)
            {
                ItemId = "{11111111-1111-1111-1111-111111111111}",
                QueryScope = new[] { SitecoreItemScope.Self }
            };

            ISitecoreWebResponse response = context.GetResponse<SitecoreWebResponse>(query);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                WriteResponseMeta(response);

                WebApiItem item = response.Result.Items[0];

                Wl("path", item.Path);
                Nl();
            }
            else
            {
                WriteError(response);
            }

            Nl();
        }

        private static void CredentialsSample(AuthenticatedSitecoreDataContext context)
        {
            var query = new SitecoreItemQuery(SitecoreQueryType.Read)
            {
                ItemId = "{11111111-1111-1111-1111-111111111111}",
                QueryScope = new[] { SitecoreItemScope.Self }
            };

            ISitecoreWebResponse response = context.GetResponse<SitecoreWebResponse>(query);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                WriteResponseMeta(response);

                WebApiItem item = response.Result.Items[0];

                Wl("path", item.Path);
                Nl();
            }
            else
            {
                WriteError(response);
            }

            Nl();
        }

        private static void FieldsSample(SitecoreDataContext context)
        {
            var query = new SitecoreItemQuery(SitecoreQueryType.Read)
                                  {
                                      ItemId = "{11111111-1111-1111-1111-111111111111}",
                                      QueryScope = new[] {SitecoreItemScope.Self}
                                  };

            ISitecoreWebResponse response = context.GetResponse<SitecoreWebResponse>(query);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                WriteResponseMeta(response);

                WebApiItem item = response.Result.Items[0];

                Wl("path", item.Path);
                Nl();

                WriteFields(item);
            }
            else
            {
                WriteError(response);
            }

            Nl();
        }

        private static void ItemQuerySample(SitecoreDataContext context)
        {
            var query = new SitecoreItemQuery(SitecoreQueryType.Read)
                                {
                                    ItemId = "{11111111-1111-1111-1111-111111111111}",
                                    QueryScope = new[] {SitecoreItemScope.Self, SitecoreItemScope.Children}
                                };

            ISitecoreWebResponse response = context.GetResponse<SitecoreWebResponse>(query);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                WriteResponseMeta(response);

                foreach (WebApiItem item in response.Result.Items)
                {
                    Wl("path", item.Path);
                }
            }
            else
            {
                WriteError(response);
            }

            Nl();
        }

        private static void ExpressionQuerySample(SitecoreDataContext context)
        {
            var query = new SitecoreExpressionQuery(SitecoreQueryType.Read)
                                      {
                                          Query = "/sitecore/content/Home/*",
                                          Payload = SitecorePayload.Min,
                                          QueryScope = new[] { SitecoreItemScope.Self }
                                      };

            ISitecoreWebResponse response = context.GetResponse<SitecoreWebResponse>(query);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                WriteResponseMeta(response);

                foreach (WebApiItem item in response.Result.Items)
                {
                    Wl("path", item.Path);
                }
            }
            else
            {
                WriteError(response);
            }

            Nl();
        }

        #region console helper methods

        /// <summary>
        /// Writes the error message from a failed response to the console.
        /// </summary>
        /// <param name="response">The response.</param>
        private static void WriteError(ISitecoreWebResponse response)
        {
            Wl("status", (int)response.StatusCode);
            Wl("message", response.Error.Message);
        }

        /// <summary>
        /// Writes the fields of the passed item to the console.
        /// </summary>
        /// <param name="item">The item.</param>
        private static void WriteFields(WebApiItem item)
        {
            foreach (KeyValuePair<string, WebApiField> field in item.Fields)
            {
                Wl("fieldid", field.Key);
                Wl("fieldname", field.Value.Name);
                Wl("fieldtype", field.Value.Type);
                Wl("fieldvalue", field.Value.Value);
                Nl();
            }
        }

        /// <summary>
        /// Writes the response meta to the console.
        /// </summary>
        /// <param name="response">The response.</param>
        private static void WriteResponseMeta(ISitecoreWebResponse response)
        {
            Wl("uri", response.Info.Uri.PathAndQuery);
            Wl("status", (int)response.StatusCode);
            Wl("description", response.StatusDescription);
            Wl("time", response.Info.ResponseTime.ToString());
            Wl("count", response.Result.TotalCount);
            Nl();
            Wl("Results");
            Nl();
        }

        /// <summary>
        /// Writes the line.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <param name="value">The value.</param>
        private static void Wl(string label, string value)
        {
            Console.WriteLine("{0}: {1}", label, value);
        }

        /// <summary>
        /// Writes the line.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <param name="value">The value.</param>
        private static void Wl(string label, int value)
        {
            Wl(label, value.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Writes the line.
        /// </summary>
        /// <param name="value">The value.</param>
        private static void Wl(string value)
        {
            Console.WriteLine(value + ":");
        }

        /// <summary>
        /// Writes an empty line to the console.
        /// </summary>
        private static void Nl()
        {
            Console.WriteLine(Environment.NewLine);
        }

        #endregion
    }
}

