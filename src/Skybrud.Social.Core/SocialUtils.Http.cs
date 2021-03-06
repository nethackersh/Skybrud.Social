﻿using System;
using System.Collections.Specialized;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;

namespace Skybrud.Social {

    public static partial class SocialUtils {

        /// <summary>
        /// Static class with helper methods related to HTTP requests and responses.
        /// </summary>
        public static class Http {

            #region DoHttpGetRequest

            /// <summary>
            /// Makes a HTTP GET request to the specified <code>url</code>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
            public static SocialHttpResponse DoHttpGetRequest(string url) {
                if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
                return DoHttpRequest(SocialHttpMethod.Get, url, default(IHttpQueryString));
            }

            /// <summary>
            /// Makes a GET request to the specified <code>url</code>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="queryString">The query string of the request.</param>
            /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
            public static SocialHttpResponse DoHttpGetRequest(string url, NameValueCollection queryString) {
                if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
                return DoHttpRequest(SocialHttpMethod.Get, url, new SocialHttpQueryString(queryString));
            }

            /// <summary>
            /// Makes a GET request to the specified <code>url</code>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="options">The options for the call to the specified <code>url</code>.</param>
            /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
            public static SocialHttpResponse DoHttpGetRequest(string url, IHttpGetOptions options) {
                if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
                if (options == null) throw new ArgumentNullException("options");
                return DoHttpRequest(SocialHttpMethod.Get, url, options.GetQueryString());
            }

            /// <summary>
            /// Makes a GET request to the specified <code>url</code>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="queryString">The query string of the request.</param>
            /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
            public static SocialHttpResponse DoHttpGetRequest(string url, IHttpQueryString queryString) {
                if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
                return DoHttpRequest(SocialHttpMethod.Get, url, queryString);
            }

            #endregion

            #region DoHttpPostRequest

            /// <summary>
            /// Makes a POST request to the specified <code>url</code>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
            public static SocialHttpResponse DoHttpPostRequest(string url) {
                if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
                return DoHttpRequest(SocialHttpMethod.Post, url, default(IHttpQueryString), default(IHttpPostData));
            }

            /// <summary>
            /// Makes a POST request to the specified <code>url</code>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="queryString">The query string of the request.</param>
            /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
            public static SocialHttpResponse DoHttpPostRequest(string url, NameValueCollection queryString) {
                return DoHttpRequest(SocialHttpMethod.Post, url, new SocialHttpQueryString(queryString), default(IHttpPostData));
            }

            /// <summary>
            /// Makes a POST request to the specified <code>url</code>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="queryString">The query string of the request.</param>
            /// <param name="postData">The POST data of the request.</param>
            /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
            public static SocialHttpResponse DoHttpPostRequest(string url, NameValueCollection queryString, NameValueCollection postData) {
                return DoHttpRequest(SocialHttpMethod.Post, url, new SocialHttpQueryString(queryString), new SocialHttpPostData(postData));
            }

            /// <summary>
            /// Makes a POST request to the specified <code>url</code>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="options">The options for the call to the specified <code>url</code>.</param>
            /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
            public static SocialHttpResponse DoHttpPostRequest(string url, IHttpGetOptions options) {
                if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
                if (options == null) throw new ArgumentNullException("options");
                return DoHttpRequest(SocialHttpMethod.Post, url, options.GetQueryString(), null);
            }

            /// <summary>
            /// Makes a POST request to the specified <code>url</code>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="options">The options for the call to the specified <code>url</code>.</param>
            /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
            public static SocialHttpResponse DoHttpPostRequest(string url, IHttpPostOptions options) {
                if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
                if (options == null) throw new ArgumentNullException("options");
                return DoHttpRequest(SocialHttpMethod.Post, url, options.GetQueryString(), options.GetPostData());
            }

            /// <summary>
            /// Makes a POST request to the specified <code>url</code>.
            /// </summary>
            /// <param name="url">The base URL of the request (no query string).</param>
            /// <param name="queryString">The query string.</param>
            /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
            public static SocialHttpResponse DoHttpPostRequest(string url, IHttpQueryString queryString) {
                return DoHttpRequest(SocialHttpMethod.Post, url, queryString, null);
            }

            /// <summary>
            /// Makes a POST request to the specified <code>url</code>.
            /// </summary>
            /// <param name="url">The base URL of the request (no query string).</param>
            /// <param name="postData">The POST data.</param>
            /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
            public static SocialHttpResponse DoHttpPostRequest(string url, IHttpPostData postData) {
                return DoHttpRequest(SocialHttpMethod.Post, url, null, postData);
            }

            /// <summary>
            /// Makes a POST request to the specified <code>url</code>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="queryString">The query string of the request.</param>
            /// <param name="postData">The POST data of the request.</param>
            /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
            public static SocialHttpResponse DoHttpPostRequest(string url, IHttpQueryString queryString, IHttpPostData postData) {
                if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");
                return DoHttpRequest(SocialHttpMethod.Post, url, queryString, postData);
            }

            #endregion

            #region DoHttpRequest

            /// <summary>
            /// Makes a HTTP request to the underlying API based on the specified parameters.
            /// </summary>
            /// <param name="method">The HTTP method of the request.</param>
            /// <param name="url">The base URL of the request (no query string).</param>
            /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
            public static SocialHttpResponse DoHttpRequest(SocialHttpMethod method, string url) {
                return DoHttpRequest(method, url, default(IHttpQueryString), default(IHttpPostData));
            }

            /// <summary>
            /// Makes a HTTP request to the underlying API based on the specified parameters.
            /// </summary>
            /// <param name="method">The HTTP method of the request.</param>
            /// <param name="url">The base URL of the request (no query string).</param>
            /// <param name="queryString">The query string.</param>
            /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
            public static SocialHttpResponse DoHttpRequest(SocialHttpMethod method, string url, NameValueCollection queryString) {
                return DoHttpRequest(method, url, new SocialHttpQueryString(queryString), null);
            }

            /// <summary>
            /// Makes a HTTP request to the underlying API based on the specified parameters.
            /// </summary>
            /// <param name="method">The HTTP method of the request.</param>
            /// <param name="url">The base URL of the request (no query string).</param>
            /// <param name="queryString">The query string.</param>
            /// <param name="postData">The POST data.</param>
            /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
            public static SocialHttpResponse DoHttpRequest(SocialHttpMethod method, string url, NameValueCollection queryString, NameValueCollection postData) {
                return DoHttpRequest(method, url, new SocialHttpQueryString(queryString), new SocialHttpPostData(postData));
            }

            /// <summary>
            /// Makes a HTTP request to the underlying API based on the specified parameters.
            /// </summary>
            /// <param name="method">The HTTP method of the request.</param>
            /// <param name="url">The base URL of the request (no query string).</param>
            /// <param name="options">The options for the call to the API.</param>
            /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
            public static SocialHttpResponse DoHttpRequest(SocialHttpMethod method, string url, IHttpGetOptions options) {
                IHttpQueryString queryString = options == null ? null : options.GetQueryString();
                return DoHttpRequest(method, url, queryString);
            }

            /// <summary>
            /// Makes a HTTP request to the underlying API based on the specified parameters.
            /// </summary>
            /// <param name="method">The HTTP method of the request.</param>
            /// <param name="url">The base URL of the request (no query string).</param>
            /// <param name="queryString">The query string.</param>
            /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
            public static SocialHttpResponse DoHttpRequest(SocialHttpMethod method, string url, IHttpQueryString queryString) {
                return DoHttpRequest(method, url, queryString, null);
            }

            /// <summary>
            /// Makes a HTTP request to the underlying API based on the specified parameters.
            /// </summary>
            /// <param name="method">The HTTP method of the request.</param>
            /// <param name="url">The base URL of the request (no query string).</param>
            /// <param name="postData">The POST data.</param>
            /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
            public static SocialHttpResponse DoHttpRequest(SocialHttpMethod method, string url, IHttpPostData postData) {
                return DoHttpRequest(method, url, null, postData);
            }

            /// <summary>
            /// Makes a HTTP request using the specified <code>url</code> and <code>method</code>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="method">The HTTP method of the request.</param>
            /// <param name="queryString">The query string of the request.</param>
            /// <param name="postData">The POST data of the request.</param>
            /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
            private static SocialHttpResponse DoHttpRequest(SocialHttpMethod method, string url, IHttpQueryString queryString, IHttpPostData postData) {

                // Initialize the request
                SocialHttpRequest request = new SocialHttpRequest {
                    Url = url,
                    Method = method,
                    QueryString = queryString,
                    PostData = postData
                };

                // Make the call to the URL
                return request.GetResponse();

            }

            #endregion

        }

    }

}