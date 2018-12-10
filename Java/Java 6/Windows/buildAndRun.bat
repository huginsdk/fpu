rm -rf classes
mkdir classes
javac -encoding UTF-8 -d classes src/Hugin/*.java src/Hugin/Test/*.java

cd classes
jar cfm ../hugin-jna-wrapper.jar ../manifest.mf *
cd ..

cd src
jar cf ../hugin-jna-wrapper-src.jar *
cd ..

java -Djava.library.path=lib -jar hugin-jna-wrapper.jar
