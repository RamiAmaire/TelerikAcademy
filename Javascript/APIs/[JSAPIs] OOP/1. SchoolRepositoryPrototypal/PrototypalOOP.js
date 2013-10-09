if (!Object.create) {
    Object.create = function (obj) {
        var f = new function () { };
        f.protrotype = obj;
        return new f();
    };
}

Object.prototype.extend = function (properties) {
    var extendedObject = function () { };
    extendedObject.prototype = Object.create(this);
    for (var prop in properties) {
        extendedObject.prototype[prop] = properties[prop];
    }
    extendedObject.prototype._super = this;

    return new extendedObject();
}