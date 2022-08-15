# CoordinatesDistanceCalculator
Distance between two points
A geodesic curve describes a line in a curved surface, this is ideal for calculating the distance between cities knowing their coordinates. If we consider the earth as sphere and not as an ellipsoid we can apply the cosine law between the points:
 
![image](https://user-images.githubusercontent.com/39188322/184658310-e9df8932-8c54-4d78-9dd9-682f332891ef.png)

cos p = cos a cos b + sin a sin b cos φ

Given the coordinates in latitude and longitude of A and B we can calculate:
a = 90Â° – lat(B)
b = 90Â° – lat(A)
φ = lon(A) – lon(B)

Given the coordinates of two cities:
53.297975, -6.372663
41.385101, -81.440440

And knowing that the radius of the earth is R = 6371 km create a c# web api .net core application that receives as input the coordinates and returns its distance in Km.

It takes only the Earth as GeometricFigure. It could be expanded in the future.
