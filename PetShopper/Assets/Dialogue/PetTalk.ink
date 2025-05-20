Hi there! #speaker: Yellow #portrait: yellow_neutral #layout: right
-> main

=== main ===
Do you prefer Cats or Dogs? #speaker: Yellow #portrait: yellow_different
+[Cats]
    ->chosen("Cat")
+[Dogs]
    ->chosen("Dog")

=== chosen(pet) ===
I prefer {pet}s! #speaker: Player #portrait: blue #layout: left
I also like {pet}s... #speaker: Yellow #portrait: yellow_neutral #layout: right
Well, anymore questions?
+[Yes]
    -> main
+[No]
    Cya!
    -> END