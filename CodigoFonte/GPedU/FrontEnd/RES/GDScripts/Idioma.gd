extends OptionButton

onready var http_request = HTTPRequest.new()

func _ready():
	PopularRequest()
	EnviarRequest()
	
func PopularRequest():
	add_child(http_request)
	http_request.connect("request_completed", self, "RequestCompleto")

func EnviarRequest():
	var error = http_request.request("http://localhost:5000/Api/Tipo/ConsultarIdiomas", [], false, HTTPClient.METHOD_POST, "Idioma")
	if error != OK:
		get_child(0).text = error

func RequestCompleto(result, response_code, headers, body):
	var response = parse_json(body.get_string_from_utf8())
	var child = get_node("./Label")
	child.text = body.get_string_from_utf8()
