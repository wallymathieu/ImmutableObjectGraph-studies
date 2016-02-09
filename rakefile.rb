require 'albacore'
require 'fileutils'
require 'nuget_helper'

include FileUtils
$sln = "immutable_object_graph-studies.sln"
task :default => [:all]

desc "Rebuild solution"
build :build do |msb, args|
  msb.prop :configuration, :Debug
  msb.target = [:Rebuild]
  msb.sln = $sln
end

desc "Install missing NuGet packages."
nugets_restore :restore do |p|
    p.out = 'packages'
    p.nuget_gem_exe
end

desc "test using console"
test_runner :test => [:build] do |runner|
  runner.exe = NugetHelper::nunit_path
  d = File.dirname(__FILE__)
  files = [File.join(d,"Tests","bin","Debug","Tests.dll")]
  runner.files = files 
end

