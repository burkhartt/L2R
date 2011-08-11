#Goal

Anytime you're writing code and you have to read it from left-to-right then right-to-left and back to left-to-right (aka all over the place), there should be an extension method to make it so that you can read everything from left-to-right. (L2R)

Here are the current estensions:

	Array.Implode(string glue); // basically like PHP's implode()
	Object.CastAs<T>(); // Darren's function
	Object.IsA<T>() / Object.IsAn<T>(); // useful for doing something like … myNumber.IsAn<int>() … instead of having to do int.TryParse()
	Object.IsNotA<T>() / Object.IsNotA<T>()
	Object.IsNull() / Object.IsNotNull()
	Object.In(array); // inverse of Array.Contains
	Object.NotIn(array); // inverse of !Array.Contains

Please add more as you think of them. BUT make sure to TDD it because even though the functions are simple, I want to make sure that we don’t mess everything up by going fast.