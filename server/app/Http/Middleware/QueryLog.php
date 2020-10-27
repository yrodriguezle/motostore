<?php

namespace App\Http\Middleware;


use Closure;
use Illuminate\Support\Facades\DB;

class QueryLog
{
  /**
   * Handle an incoming request.
   *
   * @param  \Illuminate\Http\Request  $request
   * @param  \Closure  $next
   * @param  string|null  $guard
   * @return mixed
   */
  public function handle($request, Closure $next)
  {
    DB::listen(function ($query) {
      info($query->sql);
    });

    return $next($request);
  }
}