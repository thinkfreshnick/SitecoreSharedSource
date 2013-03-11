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
                                                                    UserName = "sitecore\\foo",
                                                                    Password = "bar"
                                                                });

            // credentials

            CredentialsSample(secureContext);

            // creating

            CreateItemSample(secureContext);

            // updating using item ids

            UpdateItemIdSample(secureContext);

            // updating using queries

            UpdateItemExpressionSample(secureContext);

            // deleting

            DeleteQuerySample(secureContext);

            // encrypted credentials

            var encryptedSecureContext = new AuthenticatedSitecoreDataContext(
                host,
                new SitecoreCredentials
                    {
                        UserName = "siteore\\foo",
                        Password = "bar",
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

        /// <summary>
        /// Item creation sample
        /// </summary>
        /// <para>
        ///     Requires an authenticated data context
        /// </para>
        /// <para>
        ///     The user must have create permissions on the parent
        /// </para>
        /// <param name="context">The context.</param>
        private static void CreateItemSample(AuthenticatedSitecoreDataContext context)
        {
            var query = new SitecoreCreateQuery
            {
                Name = "Foo",
                ItemId = "{11111111-1111-1111-1111-111111111111}",
                ParentQuery = "/sitecore/content/Home",
                Template = "{11111111-1111-1111-1111-111111111111}",
                Database = "master",
                FieldsToUpdate = new Dictionary<string, string>
                                                   {
                                                       { "Field Name", "Value" },
                                                       { "{11111111-1111-1111-1111-111111111111}", "Value" }
                                                   },
                FieldsToReturn = new List<string>
                                                    {
                                                        "Field Name",
                                                        "{11111111-1111-1111-1111-111111111111}"
                                                    }
            };

            ISitecoreWebResponse response = context.GetResponse<SitecoreWebResponse>(query);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                WriteResponseMeta(response);

                foreach (WebApiItem item in response.Result.Items)
                {
                    Wl("path", item.Path);
                    WriteFields(item);
                }
            }
            else
            {
                WriteError(response);
            }

            Nl();
        }

        /// <summary>
        /// Item updating sample using item id
        /// </summary>
        /// <para>
        ///     Requires an authenticated data context
        /// </para>
        /// <para>
        ///     The user must have write permissions on the item
        /// </para>
        /// <param name="context">The context.</param>
        private static void UpdateItemIdSample(AuthenticatedSitecoreDataContext context)
        {
            var query = new SitecoreItemQuery(SitecoreQueryType.Update)
            {
                ItemId = "{11111111-1111-1111-1111-111111111111}",
                QueryScope = new[]
                                 {
                                     SitecoreItemScope.Self,
                                     SitecoreItemScope.Children
                                 },
                Database = "master",
                FieldsToUpdate = new Dictionary<string, string>
                                                   {
                                                       { "Field Name", "Value" },
                                                       { "{11111111-1111-1111-1111-111111111111}", "Value" }
                                                   },
                FieldsToReturn = new List<string> 
                                                    {
                                                        "Field Name",
                                                        "{11111111-1111-1111-1111-111111111111}"
                                                    }
            };
            
            ISitecoreWebResponse response = context.GetResponse<SitecoreWebResponse>(query);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                WriteResponseMeta(response);

                foreach (WebApiItem item in response.Result.Items)
                {
                    Wl("path", item.Path);
                    WriteFields(item);
                }
            }
            else
            {
                WriteError(response);
            }

            Nl();
        }

        /// <summary>
        /// Item updating sample using Sitecore query
        /// </summary>
        /// <para>
        ///     Requires an authenticated data context
        /// </para>
        /// <para>
        ///     The user must have write permissions on the item
        /// </para>
        /// <param name="context">The context.</param>
        private static void UpdateItemExpressionSample(AuthenticatedSitecoreDataContext context)
        {
            var query = new SitecoreExpressionQuery(SitecoreQueryType.Update)
            {
                Query = "/sitecore/content/Home",
                QueryScope = new[]
                                 {
                                     SitecoreItemScope.Self
                                 },
                Database = "master",
                FieldsToUpdate = new Dictionary<string, string>
                                                   {
                                                       { "Field Name", "Value" },
                                                       { "{11111111-1111-1111-1111-111111111111}", "Value" }
                                                   },
                FieldsToReturn = new List<string> 
                                                    {
                                                        "Field Name",
                                                        "{11111111-1111-1111-1111-111111111111}"
                                                    }
            };

            ISitecoreWebResponse response = context.GetResponse<SitecoreWebResponse>(query);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                WriteResponseMeta(response);

                foreach (WebApiItem item in response.Result.Items)
                {
                    Wl("path", item.Path);
                    WriteFields(item);
                }
            }
            else
            {
                WriteError(response);
            }

            Nl();
        }

        /// <summary>
        /// Item deletion sample
        /// </summary>
        /// <para>
        ///     Requires an authenticated data context
        /// </para>
        /// <para>
        ///     The user must have delete permissions on the item
        /// </para>
        /// <param name="context">The context.</param>
        private static void DeleteQuerySample(AuthenticatedSitecoreDataContext context)
        {
            // WARNING: all items in the query scope and their descendants will be deleted
            // only items in the query scope count toward the response count
            var query = new SitecoreItemQuery(SitecoreQueryType.Delete)
            {
                ItemId = "{11111111-1111-1111-1111-111111111111}",
                QueryScope = new[] { SitecoreItemScope.Self },
                Database = "web"
            };

            ISitecoreWebResponse response = context.GetResponse<SitecoreWebResponse>(query);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                WriteResponseMeta(response);

                Wl("deletion count", response.Result.Count);

                if (response.Result.ItemIds != null)
                {
                    foreach (string id in response.Result.ItemIds)
                    {
                        Wl("id", id);
                    }
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
                Wl("fieldname", field.Value.Name);
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

