namespace FSharpURI.Test

open FsharpURI
open Microsoft.VisualStudio.TestTools.UnitTesting
open FsharpURI.URIBuilder

[<TestClass>]
type TestClass () =

  [<TestMethod>]
  member __.``Make basic https url`` () =
    let expected = "https://google.com"
    let actual = url <| HTTPS /~ "google.com"
    Assert.AreEqual (expected, actual)

  [<TestMethod>]
  member __.``Make basic url ends with slash`` () =
    let expected = "https://google.com/"
    let actual = url <| HTTPS /~ "google.com" / ""
    Assert.AreEqual (expected, actual)

  [<TestMethod>]
  member __.``Make url with specific port`` () =
    let expected = "http://httpbin.org:80/get"
    let actual = url <| HTTP /~ "httpbin.org" /@ 80us / "get"
    Assert.AreEqual (expected, actual)

  [<TestMethod>]
  member __.``Make FTP url`` () =
    let expected = "ftp://loremipsum-ftp.org:2020"
    let actual = url <| FTP /~ "loremipsum-ftp.org" /@ 2020us
    Assert.AreEqual (expected, actual)

  [<TestMethod>]
  member __.``Make SFTP url`` () =
    let expected = "sftp://loremipsum-sftp.org:20200"
    let actual = url <| SFTP /~ "loremipsum-sftp.org" /@ 20200us
    Assert.AreEqual (expected, actual)

  [<TestMethod>]
  member __.``Make Custom scheme url`` () =
    let expected = "about://testing"
    let actual = url <| Custom "about" /~ "testing"
    Assert.AreEqual (expected, actual)
