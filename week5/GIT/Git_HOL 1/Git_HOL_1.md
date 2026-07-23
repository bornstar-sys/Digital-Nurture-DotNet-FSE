# Git HOL 1: Git Setup and Repository Configuration

## Objectives
- Setup machine with Git Configuration
- Integrate notepad++ as default editor
- Add a file to source code repository

## Step 1: Verify Git Installation
git --version

## Step 2: Configure Git Username and Email
git config --global user.name "Akeem"
git config --global user.email "akeem@example.com"

## Step 3: Verify Configuration
git config --list

## Step 4: Create New Repository
mkdir GitDemo
cd GitDemo
git init

## Step 5: Verify Hidden Git Files
ls -a

## Step 6: Create File and Add Content
echo "Welcome to Git Demo" > welcome.txt
cat welcome.txt

## Step 7: Check Git Status
git status

## Step 8: Add File to Staging Area
git add welcome.txt
git status

## Step 9: Commit the File
git commit -m "Initial commit - added welcome.txt"

## Step 10: Verify Commit Log
git log

## Key Concepts
- git init     — Initializes a new Git repository
- git status   — Shows working tree status
- git add      — Adds file to staging area
- git commit   — Saves changes to local repository
- git log      — Shows commit history
- git config   — Sets Git configuration values