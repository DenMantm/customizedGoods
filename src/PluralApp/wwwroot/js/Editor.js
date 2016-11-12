

var currentTextFont = "Georgia, serif";
var currentTextColor = "black";
var baseColor = "white";

var currentElements = [];

function changeTextFont(font){
    currentTextFont = font;
    $("#editor_font_drop_down").text(font);
}

function changeTextColor(color){
    currentTextColor = color;
    $("#editor_color_drop_down").text(color);


    var obj = canvas.getActiveObject();
    obj.color = color;

}


function changeBaseColor(color){
    baseColor = color;
var filter = new fabric.Image.filters.Tint({
                color: color,
                opacity: 0.55
            });
            base = base = canvas._objects[0];
            base.filters = [];
            base.filters.push(filter);
            base.applyFilters(canvas.renderAll.bind(canvas));
}

function editor_loadObject(){

model_object.objects[0].selectable = false;

canvas.loadFromJSON(model_object);
setTimeout(function(){ canvas.renderAll(); }, 100);
}


var model_object;
function editor_save_object(){


model_object = canvas.toObject();



}

function editor_remove_element(){
//if (confirm('Are you sure you want to remove selected?')) {
    canvas.getActiveObject().remove();
//} else {
    // Do nothing!
//}


}

function editor_add_text(){

            var element = new fabric.IText("New Text", {
            fontFamily: currentTextFont,
              left: 200,
              top: 200,
              opacity : 0.9
                });
                currentElements.push(element);
                element.setColor(currentTextColor);
                canvas.add(element);

}
