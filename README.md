# DIRS21 Data Mapper
This project demostrate that how to do mapping from one object type to another object type with strong type mapping classes.
Core engine will pick the right mapping class using the parameters passes to it `MapHandler.Map(object data, string sourceType, string targetType)`.



## How to extend with a new mapping
To extend with new mapping, need to add class that extends `IDataMapper<TSource, TTarget>` interface.

### Future improvements

* Caching the mapping classes in `MapHandler.Map` method to improve speed


