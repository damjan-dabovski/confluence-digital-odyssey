# Confluence Rules Engine
#===========================

This solution contains the 'rules engine' that automates the rules of play of *Confluence.*
It is designed as a library that is called by the server code. It acts as a 'black box' that given a current game state and corresponding command(s), returns the new, updated state, without exposing any of its internals to the calling code.