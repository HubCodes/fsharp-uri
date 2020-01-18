namespace FsharpURI

open System

type Scheme =
  | HTTP
  | HTTPS
  | FTP
  | SFTP
  | ABOUT
  | DNS
  | MAILTO
  | Custom of string
with
  override this.ToString () =
    match this with
    | HTTP -> "http"
    | HTTPS -> "https"
    | FTP -> "ftp"
    | SFTP -> "sftp"
    | ABOUT -> "about"
    | DNS -> "dns"
    | MAILTO -> "mailto"
    | Custom s -> s

type URL = Scheme * string


module URIBuilder =

  let concat ((scheme, left): URL) (right: string) =
    URL (scheme, left + "/" + right)

  let (/) = concat

  let setPort (scheme, body) (port: uint16) =
    URL (scheme, body + ":" + Convert.ToString port)

  let (/@) = setPort

  let (/~) scheme body = URL (scheme, body)

  let url ((scheme, body): URL) = scheme.ToString() + "://" + body.ToString()
